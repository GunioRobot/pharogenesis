privateTransformPrimitiveVertex: primitiveVertex byModelView: aMatrix
	| x y z rx ry rz rw oneOverW |
	x _ primitiveVertex positionX.
	y _ primitiveVertex positionY.
	z _ primitiveVertex positionZ.
	rx := (x * aMatrix a11) + (y * aMatrix a12) + (z * aMatrix a13) + aMatrix a14.
	ry := (x * aMatrix a21) + (y * aMatrix a22) + (z * aMatrix a23) + aMatrix a24.
	rz := (x * aMatrix a31) + (y * aMatrix a32) + (z * aMatrix a33) + aMatrix a34.
	rw := (x * aMatrix a41) + (y * aMatrix a42) + (z * aMatrix a43) + aMatrix a44.
	rw = 1.0 ifTrue:[
		primitiveVertex positionX: rx.
		primitiveVertex positionY: ry.
		primitiveVertex positionZ: rz.
	] ifFalse:[
		rw = 0.0 
			ifTrue:[oneOverW _ 0.0]
			ifFalse:[oneOverW _ 1.0 / rw].
		primitiveVertex positionX: rx * oneOverW.
		primitiveVertex positionY: ry * oneOverW.
		primitiveVertex positionZ: rz * oneOverW.
	].
