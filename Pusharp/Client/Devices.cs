﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Pusharp.Entities;
using Pusharp.Models;
using Pusharp.RequestParameters;

namespace Pusharp
{
    public partial class PushBulletClient
    {
        /// <summary>
        ///     Retrieves a list of all devices under the client's account.
        /// </summary>
        /// <returns>
        ///     A <see cref="Task" /> representing the asynchronous get operation. This task will resolve with a list of
        ///     <see cref="Device" /> entities, representing the devices under the client's account.
        /// </returns>
        public async Task<IReadOnlyCollection<Device>> GetDevicesAsync()
        {
            var devicesModel = await RequestClient.SendAsync<DevicesModel>("/devices", HttpMethod.Get, true, 1, null).ConfigureAwait(false);
            var downloadedDevices = devicesModel.Models;

            return downloadedDevices.Select(x => new Device(x, this)).ToImmutableList();
        }

        /// <summary>
        ///     Creates a device under the client's account.
        /// </summary>
        /// <param name="parameters">The <see cref="DeviceParameters" /> to set up the new device with.</param>
        /// <returns>
        ///     A <see cref="Task" /> representing the asynchronous post operation. This task will resolve with a
        ///     <see cref="Device" /> entity representing the created device.
        /// </returns>
        public async Task<Device> CreateDeviceAsync(DeviceParameters parameters)
        {
            var deviceModel = await RequestClient.SendAsync<DeviceModel>("/devices", HttpMethod.Post, true, 1, parameters).ConfigureAwait(false);
            var device = new Device(deviceModel, RequestClient.Client);
            //Devices.Add(device);
            return device;
        }
    }
}