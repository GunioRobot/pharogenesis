step
	| lf |
	lastSnapshot = frame ifTrue: [^ self].
	lastSnapshot := frame clone.
	lf := LiljencrantsFant new
		t0: 1 / frame f0 ro: frame ro rk: frame rk ra: frame ra samplingRate: 44000.
	glottal data: lf init samples