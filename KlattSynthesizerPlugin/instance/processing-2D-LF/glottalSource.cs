glottalSource
	| x0 |
	self inline: true.
	self returnTypeC: 'float'.
	self var: 'x0' declareC: 'float x0'.
	t0 = 0 ifTrue: [^ 0].
	nper < nopen
		ifTrue: [x0 _ a1 * x1 + (a2 * x2).
				x2 _ x1.
				x1 _ x0]
		ifFalse: [x0 _ b1 * x1 - c1.
				x1 _ x0].
	"Reset period when 'nper' reaches t0."
	nper >= t0 ifTrue: [nper _ 0. self pitchSynchronousReset].
	nper _ nper + 1.
	^ x0