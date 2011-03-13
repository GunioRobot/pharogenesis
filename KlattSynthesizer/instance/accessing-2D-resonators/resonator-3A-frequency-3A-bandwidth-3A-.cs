resonator: index frequency: freq bandwidth: bw
	"Convert formant frequencies and bandwidth into
	resonator difference equation coefficients."
	| arg r a b c |
	arg := 0.0 - Float pi / samplingRate * bw.
	r := arg exp.
	c := 0.0 - (r * r).
	arg := Float pi * 2.0 / samplingRate * freq.
	b := r * arg cos * 2.0.
	a := 1.0 - b - c.
	self resonatorA: index put: a.
	self resonatorB: index put: b.
	self resonatorC: index put: c