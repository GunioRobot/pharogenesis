english
	"Answer an english phonetic transcriber."
	^ self new rules: PhoneticRule english; phonemes: PhonemeSet arpabet; lexicon: self englishLexicon