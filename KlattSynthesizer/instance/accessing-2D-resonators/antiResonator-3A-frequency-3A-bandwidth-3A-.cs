antiResonator: index frequency: freq bandwidth: bw
	"Set up an anti-resonator"
	| arg r a b c |
	arg := 0.0 - Float pi / samplingRate * bw.
	r := arg exp.
	c := 0.0 - (r * r).
	arg := Float pi * 2.0 / samplingRate * freq.
	b := r * arg cos * 2.0.
	a := 1.0 - b - c.
	a := 1.0 / a.
	b := 0.0 - b * a.
	c := 0.0 - c * a.
	self resonatorA: index put: a.
	self resonatorB: index put: b.
	self resonatorC: index put: c