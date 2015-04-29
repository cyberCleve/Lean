﻿/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
*/

/**********************************************************
* USING NAMESPACES
**********************************************************/

using System;
using System.Collections.Generic;
using QuantConnect.Interfaces;
using QuantConnect.Lean.Engine.Results;
using QuantConnect.Packets;

namespace QuantConnect.Lean.Engine.Setup
{
    /// <summary>
    /// Interface to setup the algorithm. Pass in a raw algorithm, return one with portfolio, cash, etc already preset.
    /// </summary>
    public interface ISetupHandler
    {
        /******************************************************** 
        * INTERFACE PROPERTIES
        *********************************************************/
        /// <summary>
        /// Any errors from the initialization stored here:
        /// </summary>
        List<string> Errors 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Get the maximum runtime for this algorithm job.
        /// </summary>
        TimeSpan MaximumRuntime
        {
            get;
        }

        /// <summary>
        /// Algorithm starting capital for statistics calculations
        /// </summary>
        decimal StartingPortfolioValue
        {
            get;
        }

        /// <summary>
        /// Start date for analysis loops to search for data.
        /// </summary>
        DateTime StartingDate
        {
            get;
        }

        /// <summary>
        /// Maximum number of orders for the algorithm run -- applicable for backtests only.
        /// </summary>
        int MaxOrders
        {
            get;
        }

        /******************************************************** 
        * INTERFACE METHODS
        *********************************************************/

        /// <summary>
        /// Create a new instance of an algorithm from a physical dll path.
        /// </summary>
        /// <param name="assemblyPath">The path to the assembly's location</param>
        /// <returns>A new instance of IAlgorithm, or throws an exception if there was an error</returns>
        IAlgorithm CreateAlgorithmInstance(string assemblyPath);

        /// <summary>
        /// Primary entry point to setup a new algorithm
        /// </summary>
        /// <param name="algorithm">Algorithm instance</param>
        /// <param name="brokerage">New brokerage output instance</param>
        /// <param name="job">Algorithm job task</param>
        /// <returns>True on successfully setting up the algorithm state, or false on error.</returns>
        bool Setup(IAlgorithm algorithm, out IBrokerage brokerage, AlgorithmNodePacket job);


        /// <summary>
        /// Setup the error handler for the brokerage errors.
        /// </summary>
        /// <param name="results">Result handler.</param>
        /// <param name="brokerage">Brokerage endpoint.</param>
        /// <returns>True on successfully setting up the error handlers.</returns>
        bool SetupErrorHandler(IResultHandler results, IBrokerage brokerage);
    }
}
