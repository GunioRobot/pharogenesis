playPhoneme
	"Play a phoneme specified by the user."

	| phoneme |
	phoneme _ self selectPhonemeFromMenu: 'Phoneme to play'.
	phoneme ifNotNil: [phoneme play].
