﻿/**
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Kafka.Client.Producers.Partitioning;

namespace Kafka.Client.IntegrationTests
{
    using Kafka.Client.Producers.Partitioning;

    /// <summary>
    /// This mock partitioner will always point to the first partition (the one of index = 0)
    /// </summary>
    public class MockAlwaysZeroPartitioner : IPartitioner<string>
    {
        public int Partition(string key, int numPartitions)
        {
            return 0;
        }
    }
}
