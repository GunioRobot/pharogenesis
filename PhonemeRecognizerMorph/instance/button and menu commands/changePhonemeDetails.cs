changePhonemeDetails
	"Change the name and mouth position index of a phoneme specified by the user."

	| phoneme |
	phoneme _ self selectPhonemeFromMenu: 'Phoneme to rename'.
	phoneme ifNotNil: [self promptForDetailsOfPhoneme: phoneme].
