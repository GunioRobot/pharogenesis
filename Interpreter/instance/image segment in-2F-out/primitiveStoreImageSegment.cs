primitiveStoreImageSegment
	"This primitive is called from Squeak as...
		<imageSegment> storeSegmentFor: arrayOfRoots into: aWordArray outPointers: anArray."

"This primitive will store a binary image segment (in the same format as the Squeak image file) of the receiver and every object in its proper tree of subParts (ie, that is not refered to from anywhere else outside the tree).  All pointers from within the tree to objects outside the tree will be copied into the array of outpointers.  In their place in the image segment will be an oop equal to the offset in the outPointer array (the first would be 4). but with the high bit set."

"The primitive expects the array and wordArray to be more than adequately long.  In this case it returns normally, and truncates the two arrays to exactly the right size.  To simplify truncation, both incoming arrays are required to be 256 bytes or more long (ie with 3-word headers).  If either array is too small, the primitive will fail, but in no other case.

During operation of the primitive, it is necessary to convert from both internal and external oops to their mapped values.  To make this fast, the headers of the original objects in question are replaced by the mapped values (and this is noted by adding the forbidden XX header type).  Tables are kept of both kinds of oops, as well as of the original headers for restoration.

To be specific, there are two similar two-part tables, the outpointer array, and one in the upper fifth of the segmentWordArray.  Each grows oops from the bottom up, and preserved headers from halfway up.

In case of either success or failure, the headers must be restored.  In the event of primitive failure, the table of outpointers must also be nilled out (since the garbage in the high half will not have been discarded."

	| outPointerArray segmentWordArray savedYoungStart lastOut lastIn firstIn lastSeg endSeg segOop fieldPtr fieldOop mapOop doingClass lastPtr extraSize hdrTypeBits arrayOfRoots hdrBaseIn hdrBaseOut header firstOut versionOffset |

	outPointerArray _ self stackTop.
	segmentWordArray _ self stackValue: 1.
	arrayOfRoots _ self stackValue: 2.

	"Essential type checks"
	((self formatOf: arrayOfRoots) = 2				"Must be indexable pointers"
		and: [(self formatOf: outPointerArray) = 2				"Must be indexable pointers"
		and: [(self formatOf: segmentWordArray) = 6]])	"Must be indexable words"
		ifFalse: [^ self primitiveFail].
	((self headerType: outPointerArray) = HeaderTypeSizeAndClass	"Must be 3-word header"
		and: [(self headerType: segmentWordArray) = HeaderTypeSizeAndClass])	"Must be 3-word header"
		ifFalse: [^ self primitiveFail].

	DoAssertionChecks ifTrue: [self verifyCleanHeaders].
	"Use the top half of outPointers for saved headers."
	firstOut _ outPointerArray + BaseHeaderSize.
	lastOut _ firstOut - 4.
	hdrBaseOut _ outPointerArray + ((self lastPointerOf: outPointerArray) // 8 * 4). "top half"

	lastSeg _ segmentWordArray.
	endSeg _ segmentWordArray + (self sizeBitsOf: segmentWordArray) - 4.

	"Write a version number for byte order and version check"
	versionOffset _ 4.
	lastSeg _ lastSeg + versionOffset.
	lastSeg > endSeg ifTrue: [^ self primitiveFail].
	self longAt: lastSeg put: self imageSegmentVersion.

	"Allocate top 1/8 of segment for table of internal oops and saved headers"
	firstIn _ endSeg - ((self sizeBitsOf: segmentWordArray) // 32 * 4).  "Take 1/8 of seg"
	lastIn _ firstIn - 4.
	hdrBaseIn _ firstIn + ((self sizeBitsOf: segmentWordArray) // 64 * 4). "top half"

	"First mark the rootArray and all root objects."
	self longAt: arrayOfRoots put: ((self longAt: arrayOfRoots) bitOr: MarkBit).
	lastPtr _ arrayOfRoots + (self lastPointerOf: arrayOfRoots).
	fieldPtr _ arrayOfRoots + BaseHeaderSize.
	[fieldPtr <= lastPtr] whileTrue:
		[fieldOop _ self longAt: fieldPtr.
		(self isIntegerObject: fieldOop) ifFalse:
			[self longAt: fieldOop put: ((self longAt: fieldOop) bitOr: MarkBit)].
		fieldPtr _ fieldPtr + 4].

	"Then do a mark pass over all objects.  This will stop at our marked roots,
	thus leaving our segment unmarked in their shadow."
	savedYoungStart _ youngStart.
	youngStart _ self startOfMemory.  "process all of memory"
		"clear the recycled context lists"
		freeContexts _ NilContext.
		freeLargeContexts _ NilContext.
	self markAndTraceInterpreterOops.	"and special objects array"
	youngStart _ savedYoungStart.
	
	"Finally unmark the rootArray and all root objects."
	self longAt: arrayOfRoots put: ((self longAt: arrayOfRoots) bitAnd: AllButMarkBit).
	fieldPtr _ arrayOfRoots + BaseHeaderSize.
	[fieldPtr <= lastPtr] whileTrue:
		[fieldOop _ self longAt: fieldPtr.
		(self isIntegerObject: fieldOop) ifFalse:
			[self longAt: fieldOop put: ((self longAt: fieldOop) bitAnd: AllButMarkBit)].
		fieldPtr _ fieldPtr + 4].

	"All external objects, and only they, are now marked.
	Copy the array of roots into the segment, and forward its oop."
	lastIn _ lastIn + 4.
	lastIn >= hdrBaseIn ifTrue: [successFlag _ false].
	lastSeg _ self copyObj: arrayOfRoots toSegment: segmentWordArray addr: lastSeg stopAt: firstIn saveOopAt: lastIn headerAt: hdrBaseIn + (lastIn - firstIn).
	successFlag ifFalse:
		[lastIn _ lastIn - 4.
		self restoreHeadersFrom: firstIn to: lastIn from: hdrBaseIn and: firstOut to: lastOut from: hdrBaseOut.
		^ self primitiveFailAfterCleanup: outPointerArray].

	"Now run through the segment fixing up all the pointers.
	Note that more objects will be added to the segment as we make our way along."
	segOop _ self oopFromChunk: segmentWordArray + versionOffset + BaseHeaderSize.
	[segOop <= lastSeg] whileTrue:
		[(self headerType: segOop) <= 1
			ifTrue: ["This object has a class field (type=0 or 1) -- start with that."
					fieldPtr _ segOop - 4.  doingClass _ true]
			ifFalse: ["No class field -- start with first data field"
					fieldPtr _ segOop + BaseHeaderSize.  doingClass _ false].
		lastPtr _ segOop + (self lastPointerOf: segOop).	"last field"

		"Go through all oops, remapping them..."
		[fieldPtr > lastPtr] whileFalse:
			["Examine each pointer field"
			fieldOop _ self longAt: fieldPtr.
			doingClass ifTrue:
				[hdrTypeBits _ fieldOop bitAnd: TypeMask.
				fieldOop _ fieldOop - hdrTypeBits].
			(self isIntegerObject: fieldOop)
				ifTrue: ["Just an integer -- nothing to do"
						fieldPtr _ fieldPtr + 4]
				ifFalse:
				[header _ self longAt: fieldOop.
				(header bitAnd: TypeMask) = HeaderTypeFree
					ifTrue: ["Has already been forwarded -- this is the link"
							mapOop _ header bitAnd: AllButTypeMask]
					ifFalse:
					[((self longAt: fieldOop) bitAnd: MarkBit) = 0
						ifTrue:
							["Points to an unmarked obj -- an internal pointer.
							Copy the object into the segment, and forward its oop."
							lastIn _ lastIn + 4.
							lastIn >= hdrBaseIn ifTrue: [successFlag _ false].
							lastSeg _ self copyObj: fieldOop toSegment: segmentWordArray addr: lastSeg stopAt: firstIn saveOopAt: lastIn headerAt: hdrBaseIn + (lastIn - firstIn).
							successFlag ifFalse:
								["Out of space in segment"
								lastIn _ lastIn - 4.
								self restoreHeadersFrom: firstIn to: lastIn from: hdrBaseIn and: firstOut to: lastOut from: hdrBaseOut.
								^ self primitiveFailAfterCleanup: outPointerArray].
							mapOop _ (self longAt: fieldOop) bitAnd: AllButTypeMask]
						ifFalse:
							["Points to a marked obj -- an external pointer.
							Map it as a tagged index in outPointers, and forward its oop."
							lastOut _ lastOut + 4.
							lastOut >= hdrBaseOut ifTrue:
								["Out of space in outPointerArray"
								lastOut _ lastOut - 4.
								self restoreHeadersFrom: firstIn to: lastIn from: hdrBaseIn and: firstOut to: lastOut from: hdrBaseOut.
								^ self primitiveFailAfterCleanup: outPointerArray].
.							mapOop _ lastOut - outPointerArray bitOr: 16r80000000.
							self forward: fieldOop to: mapOop
								savingOopAt: lastOut andHeaderAt: hdrBaseOut + (lastOut - firstOut)]].
					"Replace the oop by its mapped value"
					doingClass
						ifTrue: [self longAt: fieldPtr put: mapOop + hdrTypeBits.
								fieldPtr _ fieldPtr + 8.
								doingClass _ false]
						ifFalse: [self longAt: fieldPtr put: mapOop.
								fieldPtr _ fieldPtr + 4].
]].
		segOop _ self objectAfter: segOop].

	self restoreHeadersFrom: firstIn to: lastIn from: hdrBaseIn and: firstOut to: lastOut from: hdrBaseOut.

	"Truncate the outPointerArray..."
	((outPointerArray + (self lastPointerOf: outPointerArray) - lastOut) < 12
		or: [(endSeg - lastSeg) < 12]) ifTrue:
			["Not enough room to insert simple 3-word headers"
			^ self primitiveFailAfterCleanup: outPointerArray].
	extraSize _ self extraHeaderBytes: segmentWordArray.
	hdrTypeBits _ self headerType: segmentWordArray.
	"Copy the 3-word wordArray header to establish a free chunk."
	self transfer: 3
		from: segmentWordArray - extraSize
		to: lastOut+4.
	"Adjust the size of the original as well as the free chunk."
	self longAt: lastOut+4
		put: outPointerArray + (self lastPointerOf: outPointerArray) - lastOut - extraSize + hdrTypeBits.
	self longAt: outPointerArray-extraSize
		put: lastOut - firstOut + 8 + hdrTypeBits.
	"Note that pointers have been stored into roots table"
	self beRootIfOld: outPointerArray.

	"Truncate the image segment..."
	"Copy the 3-word wordArray header to establish a free chunk."
	self transfer: 3
		from: segmentWordArray - extraSize
		to: lastSeg+4.
	"Adjust the size of the original as well as the free chunk."
	self longAt: segmentWordArray-extraSize
		put: lastSeg - segmentWordArray + BaseHeaderSize + hdrTypeBits.
	self longAt: lastSeg+4
		put: endSeg - lastSeg - extraSize + hdrTypeBits.

	DoAssertionChecks ifTrue: [self verifyCleanHeaders].
	self pop: 3.  "...leaving the reciever on the stack as return value"
