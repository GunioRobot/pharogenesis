inherentDurationAt: aPhoneme
	^ self inherents at: aPhoneme ifAbsent: [Transcript show: ' default duration for ', aPhoneme name. self defaultDurationFor: aPhoneme]