qu: u phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid
	| expuphi |
	expuphi := (u * phi) exp.
	^ expuphi * ((rphid * (u*u + 1.0) + u) * sinphi - cosphi) + 1.0