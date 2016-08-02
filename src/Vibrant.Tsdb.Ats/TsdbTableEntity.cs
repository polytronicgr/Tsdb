﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Vibrant.Tsdb.Ats.Serialization;
using Vibrant.Tsdb.Serialization;

namespace Vibrant.Tsdb.Ats
{
   internal class TsdbTableEntity : TableEntity
   {
      public const int MaxByteCapacity = ( 64 * 1024 ) - 4;
      
      public byte[] P0 { get; set; }

      public IEntry[] GetEntries( Sort sort )
      {
         return AtsSerializer.Deserialize( PartitionKey, P0, sort );
      }

      /// <summary>
      /// Split the stream as a fat entity.
      /// </summary>
      public void SetData( byte[] data )
      {
         if( null == data ) throw new ArgumentNullException( "data" );
         if( data.Length >= MaxByteCapacity ) throw new ArgumentOutOfRangeException( "data" );

         P0 = data;
      }
   }
}
