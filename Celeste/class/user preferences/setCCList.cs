setCCList
	"Change the list of names used in the default cc list. Items in the list should be valid mail addresses and should be separated by commas."

	| newList |
	(CCList isNil) ifTrue: [CCList _ ''].
	newList _ FillInTheBlank
		request: 'addresses to automatically add to CC: fields?'
		initialAnswer: CCList.
	CCList _ newList.