isFrontVowel
	"Answer true if the receiver is a front vowel phoneme."
	^ self isVowel and: [self hasFeature: #front]