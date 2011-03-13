deletePhoneme
	"Delete a phoneme specified by the user."

	| phoneme |
	phoneme := self selectPhonemeFromMenu: 'Phoneme to delete'.
	phoneme ifNotNil: [
		recognizer phonemes remove: phoneme ifAbsent: [] ].
