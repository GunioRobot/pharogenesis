width: x height: y type: collectionClass
	"Set the number of elements in the first and second dimension.
	collectionClass can be Array or String or ByteArray."

	contents == nil ifFalse:
		[self error: 'No runtime size change yet'].
		"later move all the elements to the new sized array"
	width _ x.
	contents _ collectionClass new: x * y