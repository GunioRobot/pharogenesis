deletePhoneme
	"Delete a phoneme specified by the user."

	| phoneme |
	phoneme _ self selectPhonemeFromMenu.
	phoneme ifNotNil: [
		phonemeRecords remove: phoneme ifAbsent: []].
