t0: t0 ro: roNumber rk: rkNumber ra: raNumber samplingRate: samplingRate
	| doubleN0 |
	doubleN0 _ samplingRate * t0.
	n0 _ doubleN0 asInteger.
	ne _ (doubleN0 * roNumber) asInteger.
	ro _ ne asFloat / n0 asFloat.
	rk _ rkNumber.
	ra _ raNumber