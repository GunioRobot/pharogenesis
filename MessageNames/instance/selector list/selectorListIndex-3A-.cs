selectorListIndex: anInteger 
	"Set the selectorListIndex as specified, and propagate consequences"

	selectorListIndex _ anInteger.
	selectorListIndex = 0
		ifTrue: [^ self].
	messageList _ nil.
	self changed: #selectorListIndex.
	self changed: #messageList