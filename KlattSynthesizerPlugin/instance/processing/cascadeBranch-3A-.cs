cascadeBranch: source
	"Cascade vocal tract, excited by laryngeal sources.
	Nasal antiresonator, nasal resonator, tracheal antirresonator,
	tracheal resonator, then formants F8, F7, F6, F5, F4, F3, F2, F1."
	| out |
	self inline: true.
	self returnTypeC: 'float'.
	self var: 'source' declareC: 'float source'.
	self var: 'out' declareC: 'float out'.
	cascade > 0 ifFalse: [^ 0.0].
	out _ self antiResonator: Rnz value: source.
	out _ self resonator: Rnpc value: out.
	out _ self antiResonator: Rtz value: out.
	out _ self resonator: Rtpc value: out.
	"Do not use unless sample rate >= 16000"
	cascade >= 8 ifTrue: [out _ self resonator: R8c value: out].
	"Do not use unless sample rate >= 16000"
	cascade >= 7 ifTrue: [out _ self resonator: R7c value: out].
	"Do not use unless long vocal tract or sample rate increased"
	cascade >= 6 ifTrue: [out _ self resonator: R6c value: out].
	cascade >= 5 ifTrue: [out _ self resonator: R5c value: out].
	cascade >= 4 ifTrue: [out _ self resonator: R4c value: out].
	cascade >= 3 ifTrue: [out _ self resonator: R3c value: out].
	cascade >= 2 ifTrue: [out _ self resonator: R2c value: out].
	cascade >= 1 ifTrue: [out _ self resonator: R1c value: out].
	^ out