qu: u phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid
	| expuphi |
	self returnTypeC: 'float'.
	self var: 'u' declareC: 'float u'.
	self var: 'phi' declareC: 'float phi'.
	self var: 'cosphi' declareC: 'float cosphi'.
	self var: 'sinphi' declareC: 'float sinphi'.
	self var: 'rphid' declareC: 'float rphid'.
	self var: 'expuphi' declareC: 'float expuphi'.
	expuphi _ (u * phi) exp.
	^ expuphi * ((rphid * (u*u + 1.0) + u) * sinphi - cosphi) + 1.0