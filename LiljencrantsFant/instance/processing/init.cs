init
	| d phi cosphi sinphi rphid u theta rho gamma gammapwr |
	d _ self d.
	phi _ Float pi * (rk + 1.0).
	cosphi _ phi cos.
	sinphi _ phi sin.
	rphid _ ra / ro * phi * d.

	u _ self zeroQphi: phi cosphi: cosphi sinphi: sinphi rphid: rphid.
	theta _ phi / ne.
	rho _ (u * theta) exp.
	a1 _ 2.0 * theta cos * rho.
	a2 _ 0.0 - (rho * rho).
	x1 _ 0.0.
	x2 _ rho * theta sin.

	gamma _ (-1.0 / (ra * n0)) exp.
	gammapwr _ gamma raisedTo: n0 - ne.

	b1 _ gamma.
	c1 _ (1.0 - gamma) * gammapwr / (1.0 - gammapwr)