resonator: index frequency: freq bandwidth: bw gain: gain
	"Convert formant frequencies and bandwidth into
	resonator difference equation coefficients."
	self returnTypeC: 'void'.
	self var: 'freq' declareC: 'float freq'.
	self var: 'bw' declareC: 'float bw'.
	self var: 'gain' declareC: 'float gain'.
	self resonator: index frequency: freq bandwidth: bw.
	self resonatorA: index put: (self resonatorA: index) * gain