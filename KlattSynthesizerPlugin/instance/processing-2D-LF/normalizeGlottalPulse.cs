normalizeGlottalPulse
	| s1 s2 s0 |
	self inline: true.
	self returnTypeC: 'void'.
	self var: 's0' declareC: 'float s0'.
	self var: 's1' declareC: 'float s1'.
	self var: 's2' declareC: 'float s2'.
	s0 _ 0.0.
	s1 _ x1.
	s2 _ x2.
	1 to: nopen do: [ :ingore |
		s0 _ a1 * s1 + (a2 * s2).
		s2 _ s1.
		s1 _ s0].
	s0 = 0.0 ifFalse: [x1 _ x1 / s0 * 10000.0]