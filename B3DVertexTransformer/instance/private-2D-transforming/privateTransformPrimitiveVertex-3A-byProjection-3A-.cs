privateTransformPrimitiveVertex: primitiveVertex byProjection: aMatrix
	| x y z rx ry rz rw |
	x _ primitiveVertex positionX.
	y _ primitiveVertex positionY.
	z _ primitiveVertex positionZ.
	rx := (x * aMatrix a11) + (y * aMatrix a12) + (z * aMatrix a13) + aMatrix a14.
	ry := (x * aMatrix a21) + (y * aMatrix a22) + (z * aMatrix a23) + aMatrix a24.
	rz := (x * aMatrix a31) + (y * aMatrix a32) + (z * aMatrix a33) + aMatrix a34.
	rw := (x * aMatrix a41) + (y * aMatrix a42) + (z * aMatrix a43) + aMatrix a44.
	primitiveVertex rasterPosX: rx.
	primitiveVertex rasterPosY: ry.
	primitiveVertex rasterPosZ: rz.
	primitiveVertex rasterPosW: rw.