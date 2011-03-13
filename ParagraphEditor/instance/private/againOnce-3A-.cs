againOnce: indices
	"Find the next occurrence of FindText.  If none, answer false.
	Append the start index of the occurrence to the stream indices, and, if
	ChangeText is not the same object as FindText, replace the occurrence by it.
	Note that the search is case-sensitive for replacements, otherwise not."

	| where |
	where := paragraph text findString: FindText startingAt: self stopIndex
				caseSensitive: ((ChangeText ~~ FindText) or: [Preferences caseSensitiveFinds]).
	where = 0 ifTrue: [^ false].
	self deselect; selectInvisiblyFrom: where to: where + FindText size - 1.
	ChangeText ~~ FindText ifTrue: [self zapSelectionWith: ChangeText].
	indices nextPut: where.
	self selectAndScroll.
	^ true