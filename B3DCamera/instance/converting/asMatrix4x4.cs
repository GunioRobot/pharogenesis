asMatrix4x4
	| xDir yDir zDir m |
	"calculate z vector"
	zDir _ self target - self position.
	zDir safelyNormalize.
	"calculate x vector"
	xDir _ self up cross: zDir.
	xDir safelyNormalize.
	"recalc y vector"
	yDir _ zDir cross: xDir.
	yDir safelyNormalize.
	m := B3DMatrix4x4 new.
	m	a11: xDir x;		a12: xDir y;		a13: xDir z;		a14: 0.0;
		a21: yDir x;		a22: yDir y;		a23: yDir z;		a24: 0.0;
		a31: zDir x;		a32: zDir y;		a33: zDir z;		a34: 0.0;
		a41: 0.0;			a42: 0.0;		a43: 0.0;		a44: 1.0.
	m := m composeWith: (B3DMatrix4x4 identity setTranslation: self position negated).
	^m