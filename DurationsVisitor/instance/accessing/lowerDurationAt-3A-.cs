lowerDurationAt: aPhoneme
	^ self lowers at: aPhoneme ifAbsent: [self inherentDurationAt: aPhoneme]