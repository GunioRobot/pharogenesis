initializeState
	self initializeResonators.
	pitch _ 110.0.
	t0 _ (samplingRate / pitch) asInteger.
	nper _ 0.
	nopen _ 0.
	nmod _ 0.
	periodCount _ 0.
	samplesCount _ 0.
	vlast _ 0.0.
	glast _ 0.0.
	nlast _ 0.0.

	self ro: 0.25 ra: 0.01 rk: 0.25