atPin: index 
	"Return this element of an indexable object.  Return the first or last element if index is out of bounds.  See Object at:. 6/18/96 tk"

	<primitive: 60>
	self emptyCheck.
	index isInteger ifTrue: [
		^ index < 1 ifTrue: [self first] ifFalse: [self last]].
	index isNumber
		ifTrue: [^self atPin: index asInteger]
		ifFalse: [self errorNonIntegerIndex]