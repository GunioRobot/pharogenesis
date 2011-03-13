pointOnSphereCentered: center radius: radius atPoint: aPoint
	| x y z r s |
	x := (aPoint x - center x) / radius.
	y := (aPoint y - center y) / radius.
	r := (x * x) + (y * y).
	(r > 1.0)
		ifTrue: [
			s := 1.0 / (r sqrt).
			x := s * x negated.
			y := s * y.
			z := 0.0]
		ifFalse: [ z := (1.0 - r) sqrt].
	^B3DVector3 x: x y: y negated z: z