highestUpdate
	| sortedUpdates |
	highestUpdate ifNil: [
		sortedUpdates _ self updates asSortedCollection.
		highestUpdate _ (sortedUpdates isEmpty
			ifTrue: [0]
			ifFalse: [sortedUpdates last])].
	^highestUpdate