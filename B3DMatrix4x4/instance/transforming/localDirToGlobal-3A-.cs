localDirToGlobal: aVector
	"Multiply direction vector with the receiver"
	| x y z rx ry rz |
	<primitive: 'b3dTransformDirection' module: 'Squeak3D'>
	x := aVector x.
	y := aVector y.
	z := aVector z.

	rx := (x * self a11) + (y * self a12) + (z * self a13).
	ry := (x * self a21) + (y * self a22) + (z * self a23).
	rz := (x * self a31) + (y * self a32) + (z * self a33).

	^B3DVector3 x: rx y: ry z: rz