﻿namespace PiGpio
{
    public class I2C
    {
        readonly PiGpioSharp m_pi;
        int m_handle;

        public I2C(PiGpioSharp pi)
        {
            m_pi = pi;
        }

        public void open(int bus, int address, int i2c_flags = 0)
        {
            m_handle = m_pi.executeCommand(CommandCode.PI_CMD_I2CO, bus, address, i2c_flags);
        }

        public void close()
        {
            m_pi.executeCommand(CommandCode.PI_CMD_I2CC, m_handle, 0);
        }

        public void writeDevice(byte[] data)
        {
            m_pi.executeCommand(CommandCode.PI_CMD_I2CWD, m_handle, 0, data.Length, data);
        }
    }
}
