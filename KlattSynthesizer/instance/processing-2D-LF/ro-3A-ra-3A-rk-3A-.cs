ro: roNumber ra: raNumber rk: rkNumber
	| r d phi cosphi sinphi rphid u theta rho gamma gammapwr te ro ra rk |
	te _ (t0 * roNumber) asInteger.
	ro _ te asFloat / t0 asFloat.
	rk _ rkNumber.
	ra _ raNumber.

	ra <= 0.0
		ifTrue: [d _ 1.0]
		ifFalse: [r _ 1.0 - ro / ra.
				d _ 1.0 - (r / (r exp - 1.0))].

	phi _ Float pi * (rk + 1.0).
	cosphi _ phi cos.
	sinphi _ phi sin.
	rphid _ ra / ro * phi * d.

	u _ self zeroQphi: phi cosphi: cosphi sinphi: sinphi rphid: rphid.
	theta _ phi / te.
	rho _ (u * theta) exp.
	a1 _ 2.0 * theta cos * rho.
	a2 _ 0.0 - (rho * rho).
	x2 _ 0.0.
	x1 _ rho * theta sin.

	gamma _ (-1.0 / (ra * t0)) exp.
	gammapwr _ gamma raisedTo: t0 - te.

	b1 _ gamma.
	c1 _ (1.0 - gamma) * gammapwr / (1.0 - gammapwr)