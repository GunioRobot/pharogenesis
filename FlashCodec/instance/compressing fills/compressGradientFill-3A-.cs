compressGradientFill: aFillStyle
	"Note: No terminators for simple colors"
	| ramp key |
	aFillStyle radial
		ifTrue:[stream nextPut: $R] " 'R'adial gradient"
		ifFalse:[stream nextPut: $L]. " 'L' inear gradient"
	self printPoint: aFillStyle origin on: stream.
	self printPoint: aFillStyle direction on: stream.
	self printPoint: aFillStyle normal on: stream.
	ramp := aFillStyle colorRamp.
	stream nextPut: $+; print: ramp size.
	ramp do:[:assoc|
		key := (assoc key * 255) truncated.
		stream nextPut: (Character value: key).
		self storeColor: assoc value on: stream].
	stream nextPut:$X. "Terminator"