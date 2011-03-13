zeroQphi: phi cosphi: cosphi sinphi: sinphi rphid: rphid
	| qzero ua ub qa qb uc qc |
	qzero := self qu: 0 phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid.

	qzero > 0
		ifTrue: [ua := 0. ub := 1.
				qa := qzero. qb := self qu: ub phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid.
				[qb > 0]
					whileTrue: [ua := ub. qa := qb.
								ub := ub * 2. qb := self qu: ub phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid]]
		ifFalse: [ua := -1. ub := 0.
				qa := self qu: ua phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid. qb := qzero.
				[qa < 0]
					whileTrue: [ub := ua. qb := qa.
								ua := ua * 2. qa := self qu: ua phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid]].
	[ub - ua > Epsilon]
		whileTrue: [uc := ub + ua / 2. qc := self qu: uc phi: phi cosphi: cosphi sinphi: sinphi rphid: rphid.
					qc > 0 ifTrue: [ua := uc. qa := qc] ifFalse: [ub := uc. qb := qc]].
	^ ub + ua / 2