initialize
	"B3DMatrix4x4 initialize"
	B3DZeroMatrix _ self new.
	B3DIdentityMatrix _ self new.
	B3DIdentityMatrix a11: 1.0; a22: 1.0; a33: 1.0; a44: 1.0.