resonator: index frequency: freq bandwidth: bw gain: gain
	"Convert formant frequencies and bandwidth into
	resonator difference equation coefficients."
	self resonator: index frequency: freq bandwidth: bw.
	self resonatorA: index put: (self resonatorA: index) * gain