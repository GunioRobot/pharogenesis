sweepPhase
	"Sweep memory from youngStart through the end of memory. Free all inaccessible objects and coalesce adjacent free chunks. Clear the mark bits of accessible objects. Compute the starting point for the first pass of incremental compaction (compStart). Return the number of surviving objects."
	"Details: Each time a non-free object is encountered, decrement the number of available forward table entries. If all entries are spoken for (i.e., entriesAvailable reaches zero), set compStart to the last free chunk before that object or, if there is no free chunk before the given object, the first free chunk after it. Thus, at the end of the sweep phase, compStart through compEnd spans the highest collection of non-free objects that can be accomodated by the forwarding table. This information is used by the first pass of incremental compaction to ensure that space is initially freed at the end of memory. Note that there should always be at least one free chunk--the one at the end of the heap."

	| entriesAvailable survivors freeChunk firstFree oop oopHeader oopHeaderType hdrBytes oopSize freeChunkSize |
	self inline: false.
	entriesAvailable _ self fwdTableInit.
	survivors _ 0.
	freeChunk _ nil.
	firstFree _ nil.  "will be updated later"
	oop _ self oopFromChunk: youngStart.
	[oop < endOfMemory] whileTrue: [
		"get oop's header, header type, size, and header size"
		oopHeader _ self baseHeader: oop.
		oopHeaderType _ oopHeader bitAnd: TypeMask.
		(oopHeaderType = HeaderTypeShort) ifTrue: [
			oopSize _ oopHeader bitAnd: 16rFC.
			hdrBytes _ 0.
		] ifFalse: [
			(oopHeaderType = HeaderTypeClass) ifTrue: [
				oopSize _ oopHeader bitAnd: 16rFC.
				hdrBytes _ 4.
			] ifFalse: [
				(oopHeaderType = HeaderTypeSizeAndClass) ifTrue: [
					oopSize _ (self sizeHeader: oop) bitAnd: AllButTypeMask.
					hdrBytes _ 8.
				] ifFalse: [  "free chunk"
					oopSize _ oopHeader bitAnd: FreeSizeMask.
					hdrBytes _ 0.
				].
			].
		].

		(oopHeader bitAnd: MarkBit) = 0 ifTrue: [
			"object is not marked; free it"
			freeChunk ~= nil ifTrue: [
				"enlarge current free chunk to include this oop"
				freeChunkSize _ freeChunkSize + oopSize + hdrBytes.
			] ifFalse: [
				"start a new free chunk"
				freeChunk _ oop - hdrBytes.  "chunk may start 4 or 8 bytes before oop"
				freeChunkSize _ oopSize + (oop - freeChunk).  "adjust size for possible extra header bytes"
				firstFree = nil ifTrue: [ firstFree _ freeChunk ].
			].
		] ifFalse: [
			"object is marked; clear its mark bit and possibly adjust the compaction start"
			self longAt: oop put: (oopHeader bitAnd: AllButMarkBit).
			entriesAvailable > 0 ifTrue: [
				entriesAvailable _ entriesAvailable - 1.
			] ifFalse: [
				"start compaction at the last free chunk before this object"
				firstFree _ freeChunk.
			].
			freeChunk ~= nil ifTrue: [
				"record the size of the last free chunk"
				self longAt: freeChunk
					    put: ((freeChunkSize bitAnd: FreeSizeMask) bitOr: HeaderTypeFree).
			].
			freeChunk _ nil.
			survivors _ survivors + 1.
		].
		oop _ self oopFromChunk: (oop + oopSize).  "get next oop"
	].

	freeChunk ~= nil ifTrue: [
		"record size of final free chunk"
		self longAt: freeChunk
			    put: ((freeChunkSize bitAnd: FreeSizeMask) bitOr: HeaderTypeFree).
	].

	oop = endOfMemory
		ifFalse: [ self error: 'sweep failed to find exact end of memory' ].

	firstFree = nil
		ifTrue: [ self error: 'expected to find at least one free object' ]
		ifFalse: [ compStart _ firstFree ].

	displayBits = 0 ifFalse: [
		"TPR: clear mark bit of Acorn's displayBits object, which may lie outside object space"
		oopHeader _ self baseHeader: displayBits.
		self longAt: displayBits put: (oopHeader bitAnd: AllButMarkBit)].	

	^ survivors
