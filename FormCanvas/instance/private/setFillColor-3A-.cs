setFillColor: aColor
	"Install a new color used for filling."
	| screen patternWord fillColor |
	port isFXBlt ifTrue:[port sourceMap: nil; destMap: nil; colorMap: nil; sourceKey: nil].
	fillColor _ self shadowColor ifNil:[aColor].
	fillColor ifNil:[fillColor _ Color transparent].
	fillColor isColor ifFalse:[
		(fillColor isKindOf: InfiniteForm) ifFalse:[^self error:'Cannot install color'].
		^port fillPattern: fillColor; combinationRule: Form over].
	"Okay, so fillColor really *is* a color"
	port sourceForm: nil.
	fillColor isTranslucent ifFalse:[
		port combinationRule: Form over.
		port fillPattern: fillColor.
		self depth = 8 ifTrue:[
			"In 8 bit depth it's usually a good idea to use a stipple pattern"
			port fillColor: (fillColor balancedPatternForDepth: 8)].
		^self].
	"fillColor is some translucent color"

	(port isFXBlt and:[self depth >= 8]) ifTrue:[
		"FXBlt setup for full alpha mapped transfer"
		port fillColor: (fillColor bitPatternForDepth: 32).
		port destMap: form colormapToARGB.
		port colorMap: form colormapFromARGB.
		^port combinationRule: Form blend].

	self depth > 8 ifTrue:[
		"BitBlt setup for alpha masked transfer"
		port fillPattern: fillColor.
		self depth = 16
			ifTrue:[port alphaBits: fillColor privateAlpha; combinationRule: 30]
			ifFalse:[port combinationRule: Form blend].
		^self].
	"Can't represent actual transparency -- use stipple pattern"
	screen _ Color translucentMaskFor: fillColor alpha depth: self depth.
	patternWord _ fillColor pixelWordForDepth: self depth.
	port fillPattern: (screen collect: [:maskWord | maskWord bitAnd: patternWord]).
	port combinationRule: Form paint.
