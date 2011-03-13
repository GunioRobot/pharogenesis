toggleListIndex: aNumber
	"What to do when the user chooses an item"
	listIndex == aNumber ifTrue: [listIndex _ 0]
		ifFalse: [listIndex _ aNumber].
	self changed: #listIndex.
	parent changed: #message