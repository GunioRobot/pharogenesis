playPhoneme
	"Play a phoneme specified by the user."

	| phoneme |
	phoneme _ self selectPhonemeFromMenu.
	phoneme ifNotNil: [phoneme play].
