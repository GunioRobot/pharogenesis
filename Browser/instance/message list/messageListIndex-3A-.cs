messageListIndex: anInteger 
	"Set the selected message selector to be the one indexed by anInteger."

	messageListIndex _ anInteger.
	editSelection _ 
		anInteger = 0
			ifTrue: [#newMessage]
			ifFalse: [#editMessage].
	contents _ nil.
	self changed: #messageListIndex.	"update my selection"
	self contentsChanged