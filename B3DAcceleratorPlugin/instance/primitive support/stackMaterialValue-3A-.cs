stackMaterialValue: stackIndex
	"Load a B3DMaterial from the given stack index"
	| oop |
	self inline: false.
	self returnTypeC:'void *'.
	oop _ interpreterProxy stackObjectValue: stackIndex.
	oop = nil ifTrue:[^nil].
	oop = interpreterProxy nilObject ifTrue:[^nil].
	((interpreterProxy isWords: oop) and:[(interpreterProxy slotSizeOf: oop) = MaterialSize])
		ifTrue:[^interpreterProxy firstIndexableField: oop].
	^nil