parallelVoicedBranch: source
	"Voice-excited parallel vocal tract F1, F2, F3, F4, FNP and FTP."
	self inline: true.
	self returnTypeC: 'float'.
	self var: 'source' declareC: 'float source'.
	^ (self resonator: R1vp value: source) + (self resonator: R2vp value: source) + (self resonator: R3vp value: source) + (self resonator: R4vp value: source) + (self resonator: Rnpp value: source) + (self resonator: Rtpp value: source)