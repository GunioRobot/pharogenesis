computeSamplesInto: aFloatArray
	| s0 s1 s2 |
	aFloatArray at: 1 put: x1.
	s2 := x1.
	aFloatArray at: 2 put: x2.
	s1 := x2.
	3 to: ne - 1 do: [ :each |
		s0 := a1 * s1 + (a2 * s2).
		aFloatArray at: each put: s0.
		s2 := s1.
		s1 := s0].
	ne to: n0 do: [ :each | aFloatArray at: each put: b1 * (aFloatArray at: each - 1) - c1]