messageListIndex: anInteger 
	"Set the index of the selected item to be anInteger."

	messageListIndex _ anInteger.
	contents _ 
		messageListIndex ~= 0
			ifTrue: [self selectedMessage]
			ifFalse: [''].
	self changed: #messageListIndex.	"update my selection"
	editSelection _ #editMessage.
	self contentsChanged.
	(messageListIndex ~= 0 and: [autoSelectString notNil])
		ifTrue: [self changed: #autoSelect].
