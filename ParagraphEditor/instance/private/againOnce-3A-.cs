againOnce: indices
	"Find the next occurrence of FindText.  If none, answer false.
	 Append the start index of the occurrence to the stream indices, and, if
	 ChangeText is not the same object as FindText, replace the occurrence by it."

	| where |
	where _ paragraph text findString: FindText startingAt: stopBlock stringIndex.
	where = 0 ifTrue: [^false].
	self deselect; selectInvisiblyFrom: where to: where + FindText size - 1.
	ChangeText ~~ FindText ifTrue: [self zapSelectionWith: ChangeText].
	indices nextPut: where.
	self selectAndScroll.
	^true