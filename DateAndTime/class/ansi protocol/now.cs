now
	^ self basicNew 
		ticks: (Array with: SqueakEpoch with: Time totalSeconds with: 0)
		offset: self localTimeZone offset
