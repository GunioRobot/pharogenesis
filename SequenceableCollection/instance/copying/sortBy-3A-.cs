sortBy: aBlock
	"Create a copy that is sorted.  Sort criteria is the block that accepts two arguments.
	When the block is true, the first arg goes first ([:a :b | a > b] sorts in descending
	order)."

	^ (self asSortedCollection: aBlock) asOrderedCollection