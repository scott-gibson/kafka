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

using Kafka.Client.Exceptions;
using Kafka.Client.Serialization;

namespace Kafka.Client.Responses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ProducerResponse
    {
        public short VersionId { get; set; }
        public int CorrelationId { get; set; }
        public IEnumerable<short> Errors { get; set; }
        public IEnumerable<long> Offsets { get; set; }

        ProducerResponse(short versionId, int correlationId, IEnumerable<short> errors, IEnumerable<long> offsets)
        {
            this.VersionId = versionId;
            this.CorrelationId = correlationId;
            this.Errors = errors;
            this.Offsets = offsets;
        }

        public static ProducerResponse ParseFrom(KafkaBinaryReader reader)
        {
            //should I do anything withi this:
            int length = reader.ReadInt32();

            short errorCode = reader.ReadInt16();
            if (errorCode != KafkaException.NoError)
            {
                //ignore the error
            }
            var versionId = reader.ReadInt16();
            var correlationId = reader.ReadInt32();
            var numberOfErrors = reader.ReadInt32();
            var errors = new short[numberOfErrors];
            for (int i = 0; i < numberOfErrors; i++)
            {
                errors[i] = reader.ReadInt16();
            }
            var numberOfOffsets = reader.ReadInt32();
            var offsets = new long[numberOfOffsets];
            for (int i = 0; i < numberOfOffsets; i++)
            {
                offsets[i] = reader.ReadInt64();
            }
            return new ProducerResponse(versionId, correlationId, errors, offsets);
        }
    }
}
