privateTransformPrimitiveNormal: primitiveVertex byMatrix: aMatrix rescale: scaleNeeded
	| x y z rx ry rz dot |
	x _ primitiveVertex normalX.
	y _ primitiveVertex normalY.
	z _ primitiveVertex normalZ.
	rx := (x * aMatrix a11) + (y * aMatrix a12) + (z * aMatrix a13).
	ry := (x * aMatrix a21) + (y * aMatrix a22) + (z * aMatrix a23).
	rz := (x * aMatrix a31) + (y * aMatrix a32) + (z * aMatrix a33).
	scaleNeeded ifTrue:[
		dot _ (rx * rx) + (ry * ry) + (rz * rz).
		dot < 1.0e-20 ifTrue:[
			rx _ ry _ rz _ 0.0.
		] ifFalse:[
			dot = 1.0 ifFalse:[
				dot _ 1.0 / dot sqrt.
				rx _ rx * dot.
				ry _ ry * dot.
				rz _ rz * dot.
			].
		].
	].
	primitiveVertex normalX: rx.
	primitiveVertex normalY: ry.
	primitiveVertex normalZ: rz.
