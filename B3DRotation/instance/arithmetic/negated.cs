negated
	"Negating a quaternion is the same as reversing the angle of rotation"
	^B3DRotation
		a: self a negated
		b: self b
		c: self c
		d: self d