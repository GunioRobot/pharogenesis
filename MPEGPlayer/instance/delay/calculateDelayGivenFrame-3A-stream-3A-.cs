calculateDelayGivenFrame: frame stream: aStream
	| estimated current delta |

	current _  Time millisecondClockValue  - (self startTimeForStream: aStream).
	estimated _ ((frame asFloat / self frameRate) * 1000) asInteger  - (self clockBiasForStream: aStream).
	delta _ estimated - current.
	delta > 33  ifTrue: 
		[self lastDelay: (delta + self lastDelay) // 2. 
		 (Delay forMilliseconds: self lastDelay) wait].
	delta < -33  ifTrue: 
		[self lastDelay: self lastDelay // 2.
		 self decideToSkipAFrame: delta averageWait: current//frame stream: aStream].
	