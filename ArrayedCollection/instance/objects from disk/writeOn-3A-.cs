writeOn: aStream 
	"Store the array of bits onto the argument, aStream.  (leading byte ~= 16r80) identifies this as raw bits (uncompressed).  Always store in Big Endian (Mac) byte order.  Do the writing at BitBlt speeds. We only intend this for non-pointer arrays.  Do nothing if I contain pointers."
	self class isPointers | self class isWords not ifTrue: [^ super writeOn: aStream].
				"super may cause an error, but will not be called."
	aStream nextInt32Put: self basicSize.
	aStream nextWordsPutAll: self.