instantiateClass: classPointer indexableSize: size
	| hash header1 header2 cClass byteSize format inc binc header3 hdrSize fillWord newObj sizeHiBits |
"
	NOTE: This method supports the backward-compatible split instSize field of the
	class format word.  The sizeHiBits will go away and other shifts change by 2
	when the split fields get merged in an (incompatible) image change.
"
	self inline: false.
	DoAssertionChecks ifTrue: [
		size < 0 ifTrue: [ self error: 'cannot have a negative indexable field count' ]].

	hash _ self newObjectHash.
	header1 _ self formatOfClass: classPointer. "Low 2 bits are 0"
	sizeHiBits _ (header1 bitAnd: 16r60000) >> 9.
	header1 _ (header1 bitAnd: 16r1FFFF) bitOr: ((hash << HashBitsOffset) bitAnd: HashBits).
	header2 _ classPointer.
	header3 _ 0.

	cClass _ header1 bitAnd: CompactClassMask. "compact class field from format word"
	byteSize _ (header1 bitAnd: SizeMask) + sizeHiBits. "size in bytes -- low 2 bits are 0"
	format _ (header1 >> 8) bitAnd: 16rF.

	format < 8 ifTrue: [
		"Bitmaps and Arrays"
		inc _ size * 4.
	] ifFalse: [
		"Strings and Methods"
		inc _ (size + 3) bitAnd: AllButTypeMask. "round up"
		binc _ 3 - ((size + 3) bitAnd: 3). "odd bytes"
		"low bits of byte size go in format field"
		header1 _ header1 bitOr: (binc << 8).
	].

	(byteSize + inc) > 255 ifTrue: [
		"requires size header word"
		header3 _ byteSize + inc.
		header1 _ header1 - (byteSize bitAnd: 16rFF).  "Clear qsize field"
	] ifFalse: [
		header1 _ header1 + inc.
	].
	byteSize _ byteSize + inc.

	header3 > 0 ifTrue: [
		"requires full header"
		hdrSize _ 3.
	] ifFalse: [
		cClass = 0
			ifTrue: [ hdrSize _ 2 ]
			ifFalse: [ hdrSize _ 1 ].
	].
	format <= 4  "if pointers, fill with nil oop"
		ifTrue: [ fillWord _ nilObj ]
		ifFalse: [ fillWord _ 0 ].

	newObj _ self allocate: byteSize headerSize: hdrSize h1: header1 h2: header2 h3: header3 doFill: true with: fillWord.
	^ newObj