validate: oop
	| header type cc sz fmt nextChunk | 
	header _ self longAt: oop.
	type _ header bitAnd: 3.
	type = 2 ifFalse: [type = (self rightType: header) ifFalse: [self halt]].
	sz _ (header >> 2) bitAnd: 16r3F.
	(self isFreeObject: oop)
		ifTrue: [ nextChunk _ oop + (self sizeOfFree: oop) ]
		ifFalse: [  nextChunk _ oop + (self sizeBitsOf: oop) ].
	nextChunk > endOfMemory
		ifTrue: [oop = endOfMemory ifFalse: [self halt]].
	(self headerType: nextChunk) = 0 ifTrue: [
		(self headerType: (nextChunk + 8)) = 0 ifFalse: [self halt]].
	(self headerType: nextChunk) = 1 ifTrue: [
		(self headerType: (nextChunk + 4)) = 1 ifFalse: [self halt]].
	type = 2 ifTrue:
		["free block" ^ self].
	fmt _ (header >> 8) bitAnd: 16rF.
	cc _ (header >> 12) bitAnd: 31.
	cc > 15 ifTrue: [self halt].
	type = 0 ifTrue:
		["three-word header"
		((self longAt: oop-4) bitAnd: 3) = type ifFalse: [self halt].
		((self longAt: oop-8) bitAnd: 3) = type ifFalse: [self halt].
		((self longAt: oop-4) = type) ifTrue: [self halt].	"Class word is 0"
		sz = 0 ifFalse: [self halt]].
	type = 1 ifTrue:
		["two-word header"
		((self longAt: oop-4) bitAnd: 3) = type ifFalse: [self halt].
		cc > 0 ifTrue: [sz = 1 ifFalse: [self halt]].
		sz = 0 ifTrue: [self halt]].
	type = 3 ifTrue:
		["one-word header"
		cc = 0 ifTrue: [self halt]].
	fmt = 4 ifTrue: [self halt].
	fmt = 5 ifTrue: [self halt].
	fmt = 7 ifTrue: [self halt].
	fmt >= 12 ifTrue:
		["CompiledMethod -- check for integer header"
		(self isIntegerObject: (self longAt: oop + 4)) ifFalse: [self halt]].