asPrimitiveLight
	"Convert the receiver into a B3DPrimitiveLight"
	| primLight |
	primLight _ super asPrimitiveLight.
	primLight flags: (primLight flags bitOr: FlagHasSpot).
	primLight spotMinCos: minCos.
	primLight spotMaxCos: maxCos.
	primLight spotDeltaCos: deltaCos.
	primLight spotExponent: self spotExponent.
	primLight direction: (target - (self getPositionVector)) safelyNormalize.
	^primLight