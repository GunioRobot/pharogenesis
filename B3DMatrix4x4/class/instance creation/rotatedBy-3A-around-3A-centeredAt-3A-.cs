rotatedBy: angle around: axis centeredAt: origin
	"Create a matrix rotating points around the given origin using the angle/axis pair"
	| xform |
	xform _ self withOffset: origin negated.
	xform _ xform composedWithGlobal:(B3DRotation angle: angle axis: axis) asMatrix4x4.
	xform _ xform composedWithGlobal: (self withOffset: origin).
	^xform