// Copyright ©2015-2016 Copper Mountain Technologies
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR
// ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScaleAndOffset
{
    public partial class FormMain : Form
    {
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private enum ComConnectionStateEnum
        {
            INITIALIZED,
            NOT_CONNECTED,
            CONNECTED_VNA_NOT_READY,
            CONNECTED_VNA_READY
        }

        private ComConnectionStateEnum previousComConnectionState = ComConnectionStateEnum.INITIALIZED;
        private ComConnectionStateEnum comConnectionState = ComConnectionStateEnum.NOT_CONNECTED;

        private int selectedChannel = -1;
        private int selectedTrace = -1;

        private float scale = 1.000F;
        private float offset = 0.000F;

        private bool isTriggerContinous = true;

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        public FormMain()
        {
            InitializeComponent();

            // --------------------------------------------------------------------------------------------------------

            // set form icon
            Icon = Properties.Resources.app_icon;

            // set form title
            Text = Program.programName;

            // disable resizing the window
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = true;

            // position the plug-in in the lower right corner of the screen
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(workingArea.Right - Size.Width - 130,
                                 workingArea.Bottom - Size.Height - 50);

            // always display on top
            TopMost = true;

            // --------------------------------------------------------------------------------------------------------

            // disable ui
            panelMain.Enabled = false;
            buttonTrigger.Enabled = false;

            // set version label text
            toolStripStatusLabelVersion.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

            // init scale and offset numeric entry
            upDownScale.Value = (decimal)scale;
            upDownOffset.Value = (decimal)offset;

            // update the channel selection combo box
            updateChanComboBox();

            // --------------------------------------------------------------------------------------------------------

            // start the ready timer
            readyTimer.Interval = 250; // 250 ms interval
            readyTimer.Enabled = true;
            readyTimer.Start();

            // start the update timer
            updateTimer.Interval = 250; // 250 ms interval
            updateTimer.Enabled = true;
            updateTimer.Start();

            // --------------------------------------------------------------------------------------------------------
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //
        // Timers
        //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void readyTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // is vna ready?
                if (Program.vna.app.Ready)
                {
                    // yes... vna is ready
                    comConnectionState = ComConnectionStateEnum.CONNECTED_VNA_READY;
                }
                else
                {
                    // no... vna is not ready
                    comConnectionState = ComConnectionStateEnum.CONNECTED_VNA_NOT_READY;
                }
            }
            catch (COMException)
            {
                // com connection has been lost
                comConnectionState = ComConnectionStateEnum.NOT_CONNECTED;
                Application.Exit();
                return;
            }

            if (comConnectionState != previousComConnectionState)
            {
                previousComConnectionState = comConnectionState;

                switch (comConnectionState)
                {
                    default:
                    case ComConnectionStateEnum.NOT_CONNECTED:

                        // update vna info text box
                        toolStripStatusLabelVnaInfo.ForeColor = Color.White;
                        toolStripStatusLabelVnaInfo.BackColor = Color.Red;
                        toolStripStatusLabelSpacer.BackColor = toolStripStatusLabelVnaInfo.BackColor;
                        toolStripStatusLabelVnaInfo.Text = "VNA NOT CONNECTED";

                        // disable ui
                        panelMain.Enabled = false;

                        break;

                    case ComConnectionStateEnum.CONNECTED_VNA_NOT_READY:

                        // update vna info text box
                        toolStripStatusLabelVnaInfo.ForeColor = Color.White;
                        toolStripStatusLabelVnaInfo.BackColor = Color.Red;
                        toolStripStatusLabelSpacer.BackColor = toolStripStatusLabelVnaInfo.BackColor;
                        toolStripStatusLabelVnaInfo.Text = "VNA NOT READY";

                        // disable ui
                        panelMain.Enabled = false;

                        break;

                    case ComConnectionStateEnum.CONNECTED_VNA_READY:

                        // get vna info
                        Program.vna.PopulateInfo(Program.vna.app.NAME);

                        // update vna info text box
                        toolStripStatusLabelVnaInfo.ForeColor = SystemColors.ControlText;
                        toolStripStatusLabelVnaInfo.BackColor = SystemColors.Control;
                        toolStripStatusLabelSpacer.BackColor = toolStripStatusLabelVnaInfo.BackColor;
                        toolStripStatusLabelVnaInfo.Text = Program.vna.modelString + "   " + "SN:" + Program.vna.serialNumberString + "   " + Program.vna.versionString;

                        // enable ui
                        panelMain.Enabled = true;

                        break;
                }
            }
        }

        // ------------------------------------------------------------------------------------------------------------

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (comConnectionState == ComConnectionStateEnum.CONNECTED_VNA_READY)
            {
                // update the channel combo box
                if ((comboBoxChannel.DroppedDown == false) &&
                    (comboBoxTrace.DroppedDown == false))
                {
                    updateChanComboBox();
                }

                try
                {
                    // get the trigger continuous state
                    isTriggerContinous = Program.vna.app.SCPI.INITiate[selectedChannel].CONTinuous;
                }
                catch (COMException)
                {
                }

                // update trigger button enabled
                buttonTrigger.Enabled = ((comConnectionState == ComConnectionStateEnum.CONNECTED_VNA_READY) &&
                                         !isTriggerContinous);
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //
        // Channel
        //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void updateChanComboBox()
        {
            // save previously selected channel index
            int selectedChannelIndex = comboBoxChannel.SelectedIndex;

            // prevent combo box from flickering when update occurs
            comboBoxChannel.BeginUpdate();

            // clear channel selection combo box
            comboBoxChannel.Items.Clear();

            long splitIndex = 0;
            long activeChannel = 0;
            try
            {
                // get the split index (needed to determine number of channels)
                splitIndex = Program.vna.app.SCPI.DISPlay.SPLit;

                // determine the active channel
                activeChannel = Program.vna.app.SCPI.SERVice.CHANnel.ACTive;
            }
            catch (COMException)
            {
            }

            // determine number of channels from the split index
            int numOfChannels = Program.vna.DetermineNumberOfChannels(splitIndex);

            // populate the channel number combo box
            for (int ch = 1; ch < numOfChannels + 1; ch++)
            {
                comboBoxChannel.Items.Add(ch.ToString());
            }

            if ((selectedChannelIndex == -1) ||
                (selectedChannelIndex >= comboBoxChannel.Items.Count))
            {
                // init channel selection to the active channel
                comboBoxChannel.Text = activeChannel.ToString();
            }
            else
            {
                // restore previous channel selection
                comboBoxChannel.SelectedIndex = selectedChannelIndex;
            }

            // prevent combo box from flickering when update occurs
            comboBoxChannel.EndUpdate();
        }

        private void chanComboBox_SelectedIndexChanged(object sender, EventArgs args)
        {
            // save previously selected trace index
            int selectedTraceIndex = comboBoxTrace.SelectedIndex;

            // has channel selection changed?
            if (selectedChannel != comboBoxChannel.SelectedIndex + 1)
            {
                // yes... update selected channel
                selectedChannel = comboBoxChannel.SelectedIndex + 1;
            }

            long numOfTraces = 1;
            long activeTrace = 0;
            try
            {
                // get number of traces for this channel
                numOfTraces = Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter.COUNt;

                // determine the active trace for this channel
                activeTrace = Program.vna.app.SCPI.SERVice.CHANnel[selectedChannel].TRACe.ACTive;
            }
            catch (COMException)
            {
            }

            // prevent combo box from flickering when update occurs
            comboBoxTrace.BeginUpdate();

            // clear trace selection combo box
            comboBoxTrace.Items.Clear();

            // loop thru all traces on the selected channel
            for (int tr = 1; tr < numOfTraces + 1; tr++)
            {
                string traceMeasParameter = "";
                try
                {
                    // get this trace's measurement parameter
                    traceMeasParameter = Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter[tr].DEFine;
                }
                catch (COMException)
                {
                }

                // populate trace selection combo box
                comboBoxTrace.Items.Add(tr.ToString() + " " + "(" + traceMeasParameter + ")");
            }

            // prevent combo box from flickering when update occurs
            comboBoxTrace.EndUpdate();

            if ((selectedTraceIndex == -1) ||
                (selectedTraceIndex >= comboBoxTrace.Items.Count))
            {
                // init trace selection to the active trace
                comboBoxTrace.SelectedIndex = (int)activeTrace - 1;
            }
            else
            {
                // restore previous trace selection
                comboBoxTrace.SelectedIndex = selectedTraceIndex;
            }
        }

        private void traceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // has trace selection changed?
            if (selectedTrace != comboBoxTrace.SelectedIndex + 1)
            {
                // update selected trace
                selectedTrace = comboBoxTrace.SelectedIndex + 1;
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void scaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            // update scale
            scale = (float)upDownScale.Value;
        }

        private void offsetUpDown_ValueChanged(object sender, EventArgs e)
        {
            // update offset
            offset = (float)upDownOffset.Value;
        }

        private void scaleAndOffsetResultButton_Click(object sender, EventArgs args)
        {
            // measurement data
            double[] data;

            try
            {
                object err;

                // set the trigger state to hold
                Program.vna.app.SCPI.INITiate[selectedChannel].CONTinuous = false;

                // make sure selected channel is active
                err = Program.vna.app.SCPI.DISPlay.WINDow[selectedChannel].ACTivate;

                // make sure selected trace is active
                err = Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter[selectedTrace].SELect;

                // retrieve the trace data in the format in which it is displayed
                data = Program.vna.app.SCPI.CALCulate[selectedChannel].Trace[selectedTrace].DATA.FDATa;

                for (int i = 0; i < data.Length; i = i + 2)
                {
                    // multiply the result by the scale constant provided by the user
                    data[i] = data[i] * scale;

                    // add to the result the offset provided by the user
                    data[i] = data[i] + offset;
                }

                // write the new data back to the trace
                Program.vna.app.SCPI.CALCulate[selectedChannel].Trace[selectedTrace].DATA.FDATa = data;

                // refresh display
                err = Program.vna.app.SCPI.DISPlay.REFResh.IMMediate;
            }
            catch (COMException e)
            {
                // display error message
                showMessageBoxForComException(e);
                return;
            }
        }

        private void singleTriggerButton_Click(object sender, EventArgs args)
        {
            try
            {
                object err;

                // set the trigger state to hold
                Program.vna.app.SCPI.INITiate[selectedChannel].CONTinuous = false;

                // make sure selected channel is active
                err = Program.vna.app.SCPI.DISPlay.WINDow[selectedChannel].ACTivate;

                // perform a single trigger
                err = Program.vna.app.SCPI.INITiate[selectedChannel].IMMediate;
            }
            catch (COMException e)
            {
                // display error message
                showMessageBoxForComException(e);
                return;
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void showMessageBoxForComException(COMException e)
        {
            MessageBox.Show(Program.vna.GetUserMessageForComException(e),
                Program.programName,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    }
}