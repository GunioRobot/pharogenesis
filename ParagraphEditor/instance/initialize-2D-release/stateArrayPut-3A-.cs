stateArrayPut: stateArray
	| sel |
	ChangeText _ stateArray at: 1.
	FindText _ stateArray at: 2.
	UndoInterval _ stateArray at: 3.
	UndoMessage _ stateArray at: 4.
	UndoParagraph _ stateArray at: 5.
	UndoSelection _ stateArray at: 6.
	Undone _ stateArray at: 7.
	sel _ stateArray at: 8.
	self selectFrom: sel first to: sel last.
	beginTypeInBlock _ stateArray at: 9.
	emphasisHere _ stateArray at: 10.