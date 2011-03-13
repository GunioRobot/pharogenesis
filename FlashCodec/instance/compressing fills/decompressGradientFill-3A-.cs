decompressGradientFill: radial
	"Note: No terminators for simple colors"
	| ramp fs rampSize rampIndex rampColor |
	fs := GradientFillStyle new.
	fs radial: radial.
	fs origin: (self readPointFrom: stream).
	fs direction: (self readPointFrom: stream).
	fs normal: (self readPointFrom: stream).
	stream next = $+ ifFalse:[self error:'Negative Array size'].
	rampSize := Integer readFrom: stream.
	ramp := Array new: rampSize.
	1 to: rampSize do:[:i|
		rampIndex := stream next asciiValue / 255.0.
		rampColor := self readColorFrom: stream.
		ramp at: i put: (rampIndex -> rampColor)].
	fs colorRamp: ramp.
	fs pixelRamp. "Force computation"
	stream next = $X ifFalse:[^self error:'Compressio problem'].
	^fs