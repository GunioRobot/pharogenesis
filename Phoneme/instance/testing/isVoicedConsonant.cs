isVoicedConsonant
	"Answer true if the receiver is a voiced consonant."
	^ self isVoiced and: [self isConsonant]