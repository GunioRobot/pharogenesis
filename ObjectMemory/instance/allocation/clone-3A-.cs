clone: oop
	"Return a shallow copy of the given object."
	"Assume: Oop is a real object, not a small integer."

	| extraHdrBytes bytes newChunk remappedOop fromIndex toIndex lastFrom newOop header hash |
	self inline: false.
	extraHdrBytes _ self extraHeaderBytes: oop.
	bytes _ self sizeBitsOf: oop.
	bytes _ bytes + extraHdrBytes.

	"allocate space for the copy, remapping oop in case of a GC"
	self pushRemappableOop: oop.
	newChunk _ self allocateChunk: bytes.
	remappedOop _ self popRemappableOop.

	"copy old to new including all header words"
	toIndex _ newChunk - 4.  "loop below uses pre-increment"
	fromIndex _ (remappedOop - extraHdrBytes) - 4.
	lastFrom _ fromIndex + bytes.
	[fromIndex < lastFrom] whileTrue: [
		self longAt: (toIndex _ toIndex + 4)
			put: (self longAt: (fromIndex _ fromIndex + 4)).
	].
	newOop _ newChunk + extraHdrBytes.  "convert from chunk to oop"

	"fix base header: compute new hash and clear Mark and Root bits"
	hash _ self newObjectHash.
	header _ (self longAt: newOop) bitAnd: 16r1FFFF.
		"use old ccIndex, format, size, and header-type fields"
	header _ header bitOr: ((hash << 17) bitAnd: 16r1FFE0000).
	self longAt: newOop put: header.
	^ newOop
