atWrap: index 
	"Return this element of an indexable object.  If index is out of bounds, let it wrap around from the end to the beginning until it is in bounds.  See Object at:. 6/18/96 tk"
	<primitive: 60>
	self size = 0 ifTrue: [self halt].
	index isInteger ifTrue: [
		^ self at: (index - 1 \\ self size + 1)].
	index isNumber
		ifTrue: [^self atWrap: index asInteger]
		ifFalse: [self errorNonIntegerIndex]