asPrimitiveLight
	"Convert the receiver into a B3DPrimitiveLight"
	| primLight |
	primLight _ B3DPrimitiveLight new.
	primLight ambientPart: lightColor ambientPart.
	primLight flags: FlagAmbientPart.
	^primLight