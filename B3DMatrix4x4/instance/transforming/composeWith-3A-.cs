composeWith: m2
	"Perform a 4x4 matrix multiplication."

	| c1 c2 c3 c4 m3 |
	m3 _ B3DMatrix4x4 new.

	c1 _ ((self a11 * m2 a11) + (self a12 * m2 a21) + 
				(self a13 * m2 a31) + (self a14 * m2 a41)).
	c2 _ ((self a11 * m2 a12) + (self a12 * m2 a22) + 
				(self a13 * m2 a32) + (self a14 * m2 a42)).
	c3 _ ((self a11 * m2 a13) + (self a12 * m2 a23) + 
				(self a13 * m2 a33) + (self a14 * m2 a43)).
	c4 _ ((self a11 * m2 a14) + (self a12 * m2 a24) + 
				(self a13 * m2 a34) + (self a14 * m2 a44)).

	m3 a11: c1; a12: c2; a13: c3; a14: c4.

	c1 _ ((self a21 * m2 a11) + (self a22 * m2 a21) + 
				(self a23 * m2 a31) + (self a24 * m2 a41)).
	c2 _ ((self a21 * m2 a12) + (self a22 * m2 a22) + 
				(self a23 * m2 a32) + (self a24 * m2 a42)).
	c3 _ ((self a21 * m2 a13) + (self a22 * m2 a23) + 
				(self a23 * m2 a33) + (self a24 * m2 a43)).
	c4 _ ((self a21 * m2 a14) + (self a22 * m2 a24) + 
				(self a23 * m2 a34) + (self a24 * m2 a44)).

	m3 a21: c1; a22: c2; a23: c3; a24: c4.

	c1 _ ((self a31 * m2 a11) + (self a32 * m2 a21) + 
				(self a33 * m2 a31) + (self a34 * m2 a41)).
	c2 _ ((self a31 * m2 a12) + (self a32 * m2 a22) + 
				(self a33 * m2 a32) + (self a34 * m2 a42)).
	c3 _ ((self a31 * m2 a13) + (self a32 * m2 a23) + 
				(self a33 * m2 a33) + (self a34 * m2 a43)).
	c4 _ ((self a31 * m2 a14) + (self a32 * m2 a24) + 
				(self a33 * m2 a34) + (self a34 * m2 a44)).

	m3 a31: c1; a32: c2; a33: c3; a34: c4.

	c1 _ ((self a41 * m2 a11) + (self a42 * m2 a21) + 
				(self a43 * m2 a31) + (self a44 * m2 a41)).
	c2 _ ((self a41 * m2 a12) + (self a42 * m2 a22) + 
				(self a43 * m2 a32) + (self a44 * m2 a42)).
	c3 _ ((self a41 * m2 a13) + (self a42 * m2 a23) + 
				(self a43 * m2 a33) + (self a44 * m2 a43)).
	c4 _ ((self a41 * m2 a14) + (self a42 * m2 a24) + 
				(self a43 * m2 a34) + (self a44 * m2 a44)).

	m3 a41: c1; a42: c2; a43: c3; a44: c4.

	^m3