lastPointerOf: objectPointer
	"Return the byte offset of the last pointer field of the given object. Works with CompiledMethods, as well as ordinary objects. Can be used even when the type bits are not correct."

	| fmt sz methodHeader |
	self inline: true.
	fmt _ self formatOf: objectPointer.
	fmt < 4 ifTrue: [
		sz _ self sizeBitsOfSafe: objectPointer.
		^ sz - BaseHeaderSize  "all pointers"
	].
	fmt < 12 ifTrue: [ ^0 ].  "no pointers"

	"CompiledMethod: contains both pointers and bytes:"
	methodHeader _ self longAt: objectPointer + BaseHeaderSize.
	^ ((methodHeader >> 10) bitAnd: 16rFF) * 4 + BaseHeaderSize