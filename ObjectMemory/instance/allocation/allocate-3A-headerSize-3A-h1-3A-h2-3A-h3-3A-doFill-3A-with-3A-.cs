allocate: byteSize headerSize: hdrSize h1: baseHeader h2: classOop h3: extendedSize doFill: doFill with: fillWord
	"Allocate a new object of the given size and number of header words. (Note: byteSize already includes space for the base header word.) Initialize the header fields of the new object and fill the remainder of the object with the given value."

	| newObj remappedClassOop end i |
	self inline: true.
	"remap classOop in case GC happens during allocation"
	hdrSize > 1 ifTrue: [ self pushRemappableOop: classOop ].
  	newObj _ self allocateChunk: byteSize + ((hdrSize - 1) * 4).
	hdrSize > 1 ifTrue: [ remappedClassOop _ self popRemappableOop ].

	hdrSize = 3 ifTrue: [
		self longAt: newObj      put: (extendedSize bitOr: HeaderTypeSizeAndClass).
		self longAt: newObj + 4 put: (remappedClassOop bitOr: HeaderTypeSizeAndClass).
		self longAt: newObj + 8 put: (baseHeader bitOr: HeaderTypeSizeAndClass).
		newObj _ newObj + 8.
	].
	hdrSize = 2 ifTrue: [
		self longAt: newObj      put: (remappedClassOop bitOr: HeaderTypeClass).
		self longAt: newObj + 4 put: (baseHeader bitOr: HeaderTypeClass).
		newObj _ newObj + 4.
	].
	hdrSize = 1 ifTrue: [
		self longAt: newObj put: (baseHeader bitOr: HeaderTypeShort).
	].

	"clear new object"
	doFill ifTrue:
		[end _ newObj + byteSize.
		i _ newObj + 4.
		[i < end] whileTrue:
			[self longAt: i put: fillWord.
			i _ i + 4]].

	DoAssertionChecks ifTrue: [
		self okayOop: newObj.
		self oopHasOkayClass: newObj.
		(self objectAfter: newObj) = freeBlock
			ifFalse: [ self error: 'allocate bug: did not set header of new oop correctly' ].
		(self objectAfter: freeBlock) = endOfMemory
			ifFalse: [ self error: 'allocate bug: did not set header of freeBlock correctly' ].
	].

	^ newObj