testEmptyTemplate

	"Check that an uninitialized instance behaves reasonably."

	| i |
	i _ LargeNegativeInteger new: 4.
	self assert: i size == 4.
	self assert: i printString = '-0'.
	self assert: i normalize == 0