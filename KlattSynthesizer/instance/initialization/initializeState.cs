initializeState
	self initializeResonators.
	pitch := 110.0.
	t0 := (samplingRate / pitch) asInteger.
	nper := 0.
	nopen := 0.
	nmod := 0.
	periodCount := 0.
	samplesCount := 0.
	vlast := 0.0.
	glast := 0.0.
	nlast := 0.0.

	self ro: 0.25 ra: 0.01 rk: 0.25