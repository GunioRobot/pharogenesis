isBackVowel
	"Answer true if the receiver is a back vowel phoneme."
	^ self isVowel and: [self hasFeature: #back]