defaultDurationFor: aPhoneme
	^ durations at: aPhoneme ifAbsent: [0.080]