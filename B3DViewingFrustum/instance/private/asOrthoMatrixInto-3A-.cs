asOrthoMatrixInto: aB3DMatrix4x4
	| x y z tx ty tz dx dy dz |
	(self near <= 0.0 or:[self far <= 0.0]) ifTrue: [^self error:'Clipping plane error'].
	dx := self right - self left.
	dy := self top - self bottom.
	dz := self far - self near.
	x := dx * 0.5.
	y := dy * 0.5.
	z := dz * -0.5.
	tx := (self left + self right) / dx.
	ty := (self top + self bottom) / dy.
	tz := (self near + self far) / dz.
	aB3DMatrix4x4
		a11: x;		a12: 0.0;		a13: 0.0;		a14: tx;
		a21: 0.0;		a22: y;		a23: 0.0;	a24: ty;
		a31: 0.0;		a32: 0.0;	a33: z;		a34: tz;
		a41: 0.0;		a42: 0.0;	a43: 0.0;	a44: 1.0.
	^aB3DMatrix4x4