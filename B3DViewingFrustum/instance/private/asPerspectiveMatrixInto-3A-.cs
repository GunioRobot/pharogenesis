asPerspectiveMatrixInto: aB3DMatrix4x4
	| x y a b c d dx dy dz z2 |
	(self near <= 0.0 or:[self far <= 0.0 or:[self near >= self far]]) 
		ifTrue: [^self error:'Clipping plane error'].
	dx := self right - self left.
	dy := self top - self bottom.
	dz := self far - self near.
	z2 := 2.0 * self near.
	x := z2 / dx.
	y := z2 / dy.
	a := (self left + self right) / dx.
	b := (self top + self bottom) / dy.
	c := (self near + self far) "*negated*" / dz.
	d := (-2.0 * self near * self far) / dz.
	aB3DMatrix4x4
		a11: x;		a12: 0.0;		a13: a;		a14: 0.0;
		a21: 0.0;		a22: y;		a23: b;		a24: 0.0;
		a31: 0.0;		a32: 0.0;	a33: c;		a34: d;
		a41: 0.0;		a42: 0.0;	a43: "*-1*"1;		a44: 0.0.
	^aB3DMatrix4x4