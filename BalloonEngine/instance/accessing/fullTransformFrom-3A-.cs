fullTransformFrom: aMatrix
	| m |
	m _ self aaTransform composedWith: aMatrix.
	"m offset: m offset + destOffset."
	^m