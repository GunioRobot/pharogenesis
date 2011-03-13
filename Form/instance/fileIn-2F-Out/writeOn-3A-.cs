writeOn: file
	"Write the receiver on the file in the format
		depth, extent, offset, bits."
	file nextPut: depth.
	file nextWordPut: width.
	file nextWordPut: height.
	file nextWordPut: ((self offset x) >=0
					ifTrue: [self offset x]
					ifFalse: [self offset x + 65536]).
	file nextWordPut: ((self offset y) >=0
					ifTrue: [self offset y]
					ifFalse: [self offset y + 65536]).
	bits writeOn: file