asPrimitiveLight
	"Convert the receiver into a B3DPrimitiveLight"
	| primLight flags |
	primLight _ B3DPrimitiveLight new.
	primLight direction: (self getRotationVector).
	flags _ FlagDirectional.
	lightColor ambientPart isZero ifFalse:[
		primLight ambientPart: lightColor ambientPart.
		flags _ flags bitOr: FlagAmbientPart].
	lightColor diffusePart isZero ifFalse:[
		primLight diffusePart: lightColor diffusePart.
		flags _ flags bitOr: FlagDiffusePart].
	lightColor specularPart isZero ifFalse:[
		primLight specularPart: lightColor specularPart.
		flags _ flags bitOr: FlagSpecularPart].
	primLight flags: flags.
	^primLight