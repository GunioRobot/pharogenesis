bytes: aBytesOop Lshift: shiftCount 
	"Attention: this method invalidates all oop's! Only newBytes is valid at return."
	"Does not normalize."
	| newBytes highBit newLen oldLen |
	oldLen _ self byteSizeOfBytes: aBytesOop.
	(highBit _ self cBytesHighBit: (interpreterProxy firstIndexableField: aBytesOop)
				len: oldLen) = 0 ifTrue: [^ 0 asOop: SmallInteger].
	newLen _ highBit + shiftCount + 7 // 8.
	self remapOop: aBytesOop in: [newBytes _ interpreterProxy instantiateClass: (interpreterProxy fetchClassOf: aBytesOop)
					indexableSize: newLen].
	self
		cBytesLshift: shiftCount
		from: (interpreterProxy firstIndexableField: aBytesOop)
		len: oldLen
		to: (interpreterProxy firstIndexableField: newBytes)
		len: newLen.
	^ newBytes