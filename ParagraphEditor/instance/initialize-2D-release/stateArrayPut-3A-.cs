stateArrayPut: stateArray
	| sel |
	ChangeText := stateArray at: 1.
	FindText := stateArray at: 2.
	UndoInterval := stateArray at: 3.
	UndoMessage := stateArray at: 4.
	UndoParagraph := stateArray at: 5.
	UndoSelection := stateArray at: 6.
	Undone := stateArray at: 7.
	sel := stateArray at: 8.
	self selectFrom: sel first to: sel last.
	beginTypeInBlock := stateArray at: 9.
	emphasisHere := stateArray at: 10.