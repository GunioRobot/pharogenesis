privateTransformPrimitiveVertex: primitiveVertex byModelViewWithoutW: aMatrix
	"Special case of aMatrix a41 = a42 = a43 = 0.0 and a44 = 1.0"
	| x y z rx ry rz |
	"Note: This is not supported by primitive level operations."
	self flag: #b3dPrimitive.
	x _ primitiveVertex positionX.
	y _ primitiveVertex positionY.
	z _ primitiveVertex positionZ.
	rx := (x * aMatrix a11) + (y * aMatrix a12) + (z * aMatrix a13) + aMatrix a14.
	ry := (x * aMatrix a21) + (y * aMatrix a22) + (z * aMatrix a23) + aMatrix a24.
	rz := (x * aMatrix a31) + (y * aMatrix a32) + (z * aMatrix a33) + aMatrix a34.
	primitiveVertex positionX: rx.
	primitiveVertex positionY: ry.
	primitiveVertex positionZ: rz.