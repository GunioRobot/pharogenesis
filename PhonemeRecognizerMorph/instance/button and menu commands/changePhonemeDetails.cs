changePhonemeDetails
	"Change the name and mouth position index of a phoneme specified by the user."

	| phoneme |
	phoneme _ self selectPhonemeFromMenu.
	phoneme ifNotNil: [self promptForDetailsOfPhoneme: phoneme].
