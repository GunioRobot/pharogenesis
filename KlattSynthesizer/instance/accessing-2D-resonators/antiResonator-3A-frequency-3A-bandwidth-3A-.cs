antiResonator: index frequency: freq bandwidth: bw
	"Set up an anti-resonator"
	| arg r a b c |
	arg _ 0.0 - Float pi / samplingRate * bw.
	r _ arg exp.
	c _ 0.0 - (r * r).
	arg _ Float pi * 2.0 / samplingRate * freq.
	b _ r * arg cos * 2.0.
	a _ 1.0 - b - c.
	a _ 1.0 / a.
	b _ 0.0 - b * a.
	c _ 0.0 - c * a.
	self resonatorA: index put: a.
	self resonatorB: index put: b.
	self resonatorC: index put: c