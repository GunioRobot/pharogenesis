now
	^ self basicNew 
		ticks: (Duration 
				days: SqueakEpoch 
				hours: 0 
				minutes: 0 
				seconds: self totalSeconds 
				nanoSeconds: 0) ticks
		offset: self localOffset;
		yourself
