stackPointerIndex
	"Return the 0-based index rel to the current context.
	(This is what stackPointer used to be before conversion to pointer"
	^ (stackPointer - activeContext - BaseHeaderSize) >> 2