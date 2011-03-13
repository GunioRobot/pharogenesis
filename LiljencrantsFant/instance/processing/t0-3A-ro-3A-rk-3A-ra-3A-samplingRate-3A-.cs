t0: t0 ro: roNumber rk: rkNumber ra: raNumber samplingRate: samplingRate
	| doubleN0 |
	doubleN0 := samplingRate * t0.
	n0 := doubleN0 asInteger.
	ne := (doubleN0 * roNumber) asInteger.
	ro := ne asFloat / n0 asFloat.
	rk := rkNumber.
	ra := raNumber