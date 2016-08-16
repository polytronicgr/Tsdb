﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vibrant.Tsdb
{
   public class Serie<TKey, TEntry> : ISerie<TKey, TEntry>
     where TEntry : IEntry
   {
      public Serie( TKey key, List<TEntry> entries )
      {
         Key = key;
         Entries = entries;
      }

      public Serie( TKey key, TEntry entry )
      {
         Key = key;
         Entries = new List<TEntry>();
         Entries.Add( entry );
      }

      public TKey Key { get; private set; }

      public List<TEntry> Entries { get; private set; }
   }
}
