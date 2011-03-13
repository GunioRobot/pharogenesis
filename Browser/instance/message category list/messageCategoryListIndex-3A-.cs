messageCategoryListIndex: anInteger 
	"Set the selected message category to be the one indexed by anInteger."

	messageCategoryListIndex _ anInteger.
	messageListIndex _ 0.
	editSelection _ 
		anInteger <= 1
			ifTrue: [#editClass]
			ifFalse: [#newMessage].
	contents _ nil.
	self changed: #messageCategorySelectionChanged.
	self changed: #messageCategoryListIndex.	"update my selection"
	self changed: #messageList.
	self contentsChanged
