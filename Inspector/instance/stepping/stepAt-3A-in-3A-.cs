stepAt: millisecondClockValue in: aWindow
	| newText |

	(Preferences smartUpdating and: [(millisecondClockValue - self timeOfLastListUpdate) > 8000]) "Not more often than once every 8 seconds"
		ifTrue:
			[self updateListsAndCodeIn: aWindow.
			timeOfLastListUpdate _ millisecondClockValue].

	newText _ self contentsIsString
		ifTrue: [self selection]
		ifFalse: ["keep it short to reduce time to compute it"
			self selectionPrintString ].
	newText = contents ifFalse:
		[contents _ newText.
		self changed: #contents]