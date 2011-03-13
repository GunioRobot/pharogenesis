todayAtNanoSeconds: nanoSecondsSinceMidnight

	^ self basicNew
			setJdn: DaysSinceEpoch 
			seconds: (nanoSecondsSinceMidnight // 1000000000) 
			nano: (nanoSecondsSinceMidnight  \\ 1000000000  ) 
			offset: self localOffset
 