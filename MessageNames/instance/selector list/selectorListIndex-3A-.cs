selectorListIndex: anInteger 
	"Set the selectorListIndex as specified, and propagate consequences"

	selectorListIndex := anInteger.
	selectorListIndex = 0
		ifTrue: [^ self].
	messageList := nil.
	self changed: #selectorListIndex.
	self changed: #messageList