parallelFrictionBranch: source
	"Friction-excited parallel vocal tract formants F6, F5, F4, F3, F2,
	outputs added with alternating sign. Sound source for other
	parallel resonators is friction plus first difference of
	voicing waveform."
	self inline: true.
	self returnTypeC: 'float'.
	self var: 'source' declareC: 'float source'.
	^ (self resonator: R2fp value: source) - (self resonator: R3fp value: source) + (self resonator: R4fp value: source) - (self resonator: R5fp value: source) + (self resonator: R6fp value: source)