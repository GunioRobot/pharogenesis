ro: roNumber ra: raNumber rk: rkNumber
	| r d phi cosphi sinphi rphid u theta rho gamma gammapwr te ro ra rk |

	self returnTypeC: 'void'.
	self var: 'roNumber' declareC: 'float roNumber'.
	self var: 'raNumber' declareC: 'float raNumber'.
	self var: 'rkNumber' declareC: 'float rkNumber'.
	self var: 'r' declareC: 'float r'.
	self var: 'd' declareC: 'float d'.
	self var: 'phi' declareC: 'float phi'.
	self var: 'cosphi' declareC: 'float cosphi'.
	self var: 'sinphi' declareC: 'float sinphi'.
	self var: 'rphid' declareC: 'float rphid'.
	self var: 'u' declareC: 'float u'.
	self var: 'theta' declareC: 'float theta'.
	self var: 'rho' declareC: 'float rho'.
	self var: 'gamma' declareC: 'float gamma'.
	self var: 'gammapwr' declareC: 'float gammapwr'.
	self var: 'ro' declareC: 'float ro'.
	self var: 'ra' declareC: 'float ra'.
	self var: 'rk' declareC: 'float rk'.

	te _ (t0 * roNumber) asInteger.
	ro _ te asFloat / t0 asFloat.
	rk _ rkNumber.
	ra _ raNumber.

	ra <= 0.0
		ifTrue: [d _ 1.0]
		ifFalse: [r _ 1.0 - ro / ra.
				d _ 1.0 - (r / (r exp - 1.0))].

	phi _ PI * (rk + 1.0).
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
	c1 _ (1.0 - gamma) * gammapwr / (1.0 - gammapwr).

	self normalizeGlottalPulse