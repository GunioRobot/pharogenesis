zeroQphi: phi cosphi: cosphi sinphi: sinphi rphid: rphid
	| qzero ua ub qa qb uc qc |
	self returnTypeC: 'float'.
	self var: 'qzero' declareC: 'float qzero'.
	self var: 'ua' declareC: 'float ua'.
	self var: 'ub' declareC: 'float ub'.
	self var: 'qa' declareC: 'float qa'.
	self var: 'qb' declareC: 'float qb'.
	self var: 'uc' declareC: 'float uc'.
	self var: 'qc' declareC: 'float qc'.
	self var: 'phi' declareC: 'float phi'.
	self var: 'cosphi' declareC: 'float cosphi'.
	self var: 'sinphi' declareC: 'float sinphi'.
	self var: 'rphid' declareC: 'float rphid'.

	qzero _ self qu: 0 phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid.

	qzero > 0
		ifTrue: [ua _ 0. ub _ 1.
				qa _ qzero. qb _ self qu: ub phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid.
				[qb > 0]
					whileTrue: [ua _ ub. qa _ qb.
								ub _ ub * 2. qb _ self qu: ub phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid]]
		ifFalse: [ua _ -1. ub _ 0.
				qa _ self qu: ua phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid. qb _ qzero.
				[qa < 0]
					whileTrue: [ub _ ua. qb _ qa.
								ua _ ua * 2. qa _ self qu: ua phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid]].
	[ub - ua > Epsilon]
		whileTrue: [uc _ ub + ua / 2.0. qc _ self qu: uc phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid.
					qc > 0 ifTrue: [ua _ uc. qa _ qc] ifFalse: [ub _ uc. qb _ qc]].
	^ ub + ua / 2.0