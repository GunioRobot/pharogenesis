loadGradientFill: rampOop from: point1 along: point2 normal: point3 isRadial: isRadial
	"Load the gradient fill as defined by the color ramp."
	| rampWidth fill |
	self inline: false.
	self var: #point1 declareC:'int *point1'.
	self var: #point2 declareC:'int *point2'.
	self var: #point3 declareC:'int *point3'.
	(interpreterProxy fetchClassOf: rampOop) = interpreterProxy classBitmap
		ifFalse:[^interpreterProxy primitiveFail].
	rampWidth _ interpreterProxy slotSizeOf: rampOop.
	fill _ self allocateGradientFill: (interpreterProxy firstIndexableField: rampOop)
				rampWidth: rampWidth isRadial: isRadial.
	engineStopped ifTrue:[^nil].
	self loadFillOrientation: fill 
		from: point1 along: point2 normal: point3 
		width: rampWidth height: rampWidth.
	^fill