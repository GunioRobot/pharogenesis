setCCList
	"Change the list of names used in the default cc list. Items in the list should be valid mail addresses and should be separated by commas."

	self ccList: (FillInTheBlank
		request: 'addresses to automatically add to CC: fields?'
		initialAnswer: self ccList).
	^ ccList