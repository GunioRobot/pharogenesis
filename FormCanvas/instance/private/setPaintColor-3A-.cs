setPaintColor: aColor
	"Install a new color used for filling."
	| paintColor screen patternWord |
	port isFXBlt ifTrue:[port sourceMap: nil; destMap: nil; colorMap: nil; sourceKey: nil].
	paintColor _ self shadowColor ifNil:[aColor].
	paintColor ifNil:[paintColor _ Color transparent].
	paintColor isColor ifFalse:[
		(paintColor isKindOf: InfiniteForm) ifFalse:[^self error:'Cannot install color'].
		^port fillPattern: paintColor; combinationRule: Form paint].
	"Okay, so paintColor really *is* a color"
	port sourceForm: nil.
	(paintColor isTranslucent) ifFalse:[
		port fillPattern: paintColor.
		port combinationRule: Form paint.
		self depth = 8 ifTrue:[
			port fillColor: (paintColor balancedPatternForDepth: 8)].
		^self].
	"paintColor is translucent color"
	(port isFXBlt and:[self depth >= 8]) ifTrue:[
		"FXBlt setup for alpha mapped transfer"
		port fillPattern: paintColor.
		port fillColor: (paintColor bitPatternForDepth: 32).
		port destMap: form colormapToARGB.
		port colorMap: form colormapFromARGB.
		port combinationRule: Form blend.
		^self].

	self depth > 8 ifTrue:[
		"BitBlt setup for alpha mapped transfer"
		port fillPattern: paintColor.
		self depth = 16
			ifTrue:[port alphaBits: paintColor privateAlpha; combinationRule: 31]
			ifFalse:[port combinationRule: Form blend].
		^self].

	"Can't represent actual transparency -- use stipple pattern"
	screen _ Color translucentMaskFor: paintColor alpha depth: self depth.
	patternWord _ paintColor pixelWordForDepth: self depth.
	port fillPattern: (screen collect: [:maskWord | maskWord bitAnd: patternWord]).
	port combinationRule: Form paint
