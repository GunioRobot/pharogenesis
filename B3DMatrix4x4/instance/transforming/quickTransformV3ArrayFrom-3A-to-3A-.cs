quickTransformV3ArrayFrom: srcArray to: dstArray
	"Transform the 3 element vertices from srcArray to dstArray.
	ASSUMPTION: a41 = a42 = a43 = 0.0 and a44 = 1.0"
	| a11 a12 a13 a14 a21 a22 a23 a24 a31 a32 a33 a34 x y z index |
	self flag: #b3dPrimitive.
	a11 _ self a11.	a12 _ self a12.	a13 _ self a13.	a14 _ self a14.
	a21 _ self a21.	a22 _ self a22.	a23 _ self a23.	a24 _ self a24.
	a31 _ self a31.	a32 _ self a32.	a33 _ self a33.	a34 _ self a34.
	1 to: srcArray size do:[:i|
		index _ i-1*3.
		x _ srcArray floatAt: index+1.
		y _ srcArray floatAt: index+2.
		z _ srcArray floatAt: index+3.
		dstArray floatAt: index+1 put: (a11*x) + (a12*y) + (a13*z) + a14.
		dstArray floatAt: index+2 put: (a21*x) + (a22*y) + (a23*z) + a24.
		dstArray floatAt: index+3 put: (a31*x) + (a32*y) + (a33*z) + a34.
	].
	^dstArray