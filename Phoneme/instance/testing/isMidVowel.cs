isMidVowel
	"Answer true if the receiver is a mid vowel phoneme."
	^ self isVowel and: [self hasFeature: #mid]