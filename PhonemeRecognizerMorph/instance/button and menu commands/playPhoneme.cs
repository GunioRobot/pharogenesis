playPhoneme
	"Play a phoneme specified by the user."

	| phoneme |
	
	phoneme := self selectPhonemeFromMenu: 'Phoneme to play'.
	phoneme ifNotNil: [
		"Stop recognizing otherwise I can't play the phoneme"
		self stopRecognizing.
		"Play the phoneme"
		phoneme play.
	].
