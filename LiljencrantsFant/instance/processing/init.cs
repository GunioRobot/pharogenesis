init
	| d phi cosphi sinphi rphid u theta rho gamma gammapwr |
	d := self d.
	phi := Float pi * (rk + 1.0).
	cosphi := phi cos.
	sinphi := phi sin.
	rphid := ra / ro * phi * d.

	u := self zeroQphi: phi cosphi: cosphi sinphi: sinphi rphid: rphid.
	theta := phi / ne.
	rho := (u * theta) exp.
	a1 := 2.0 * theta cos * rho.
	a2 := 0.0 - (rho * rho).
	x1 := 0.0.
	x2 := rho * theta sin.

	gamma := (-1.0 / (ra * n0)) exp.
	gammapwr := gamma raisedTo: n0 - ne.

	b1 := gamma.
	c1 := (1.0 - gamma) * gammapwr / (1.0 - gammapwr)