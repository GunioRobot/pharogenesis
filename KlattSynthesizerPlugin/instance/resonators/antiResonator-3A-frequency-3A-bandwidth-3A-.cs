antiResonator: index frequency: freq bandwidth: bw
	"Set up an anti-resonator"
	| arg r a b c |
	self returnTypeC: 'void'.
	self var: 'freq' declareC: 'float freq'.
	self var: 'bw' declareC: 'float bw'.
	self var: 'arg' declareC: 'double arg'.
	self var: 'a' declareC: 'float a'.
	self var: 'b' declareC: 'float b'.
	self var: 'c' declareC: 'float c'.
	self var: 'r' declareC: 'float r'.
	arg _ 0.0 - PI / samplingRate * bw.
	r _ arg exp.
	c _ 0.0 - (r * r).
	arg _ PI * 2.0 / samplingRate * freq.
	b _ r * arg cos * 2.0.
	a _ 1.0 - b - c.
	a _ 1.0 / a.
	b _ 0.0 - b * a.
	c _ 0.0 - c * a.
	self resonatorA: index put: a.
	self resonatorB: index put: b.
	self resonatorC: index put: c