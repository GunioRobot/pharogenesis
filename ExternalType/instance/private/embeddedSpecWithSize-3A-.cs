embeddedSpecWithSize: typeSize
	"Return a compiled spec for embedding in a new compiled spec."
	| spec header |
	spec _ self compiledSpec copy.
	header _ spec at: 1.
	header _ (header bitAnd: FFIStructSizeMask bitInvert32) bitOr: typeSize.
	spec at: 1 put: header.
	(self isStructureType and:[self isPointerType not])
		ifTrue:[spec _ spec copyWith: self class structureSpec].
	^spec