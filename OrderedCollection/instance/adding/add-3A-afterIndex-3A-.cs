add: newObject afterIndex: index 
	"Add the argument, newObject, as an element of the receiver. Put it in 
	the sequence just after index. Answer newObject."

	self insert: newObject before: firstIndex + index.
	^ newObject