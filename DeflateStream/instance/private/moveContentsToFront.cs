moveContentsToFront
	"Move the contents of the receiver to the front"
	| delta |
	delta _ (blockPosition - WindowSize).
	delta <= 0 ifTrue:[^self].
	"Move collection"
	collection 
		replaceFrom: 1 
		to: collection size - delta 
		with: collection 
		startingAt: delta+1.
	position _ position - delta.
	"Move hash table entries"
	blockPosition _ blockPosition - delta.
	blockStart _ blockStart - delta.
	self updateHashTable: hashHead delta: delta.
	self updateHashTable: hashTail delta: delta.