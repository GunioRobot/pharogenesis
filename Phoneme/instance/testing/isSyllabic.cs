isSyllabic
	"Answer true if the receiver is a syllabic consonant (or a vowel)."
	^ self isVowel or: [self isDiphthong]