messageListIndex: anInteger
	"Set the selected message selector to be the one indexed by anInteger."

	messageListIndex _ anInteger.
	self editSelection: (anInteger > 0
		ifTrue: [#editMessage]
		ifFalse: [self messageCategoryListIndex > 0
			ifTrue: [#newMessage]
			ifFalse: [self classListIndex > 0
				ifTrue: [#editClass]
				ifFalse: [#newClass]]]).
	contents _ nil.
	self changed: #messageListIndex. "update my selection"
	self contentsChanged.
	self decorateButtons.