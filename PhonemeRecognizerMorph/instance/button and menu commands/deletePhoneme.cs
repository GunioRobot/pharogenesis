deletePhoneme
	"Delete a phoneme specified by the user."

	| phoneme |
	phoneme _ self selectPhonemeFromMenu: 'Phoneme to delete'.
	phoneme ifNotNil: [
		phonemeRecords remove: phoneme ifAbsent: []].
