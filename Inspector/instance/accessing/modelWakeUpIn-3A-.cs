modelWakeUpIn: aWindow
	| newText |
	self updateListsAndCodeIn: aWindow.
	newText _ self contentsIsString
		ifTrue: [newText _ self selection]
		ifFalse: ["keep it short to reduce time to compute it"
			self selectionPrintString ].
	newText = contents ifFalse:
		[contents _ newText.
		self changed: #contents]