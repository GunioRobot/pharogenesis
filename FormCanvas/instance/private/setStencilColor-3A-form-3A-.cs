setStencilColor: aColor form: sourceForm
	"Install a new color used for stenciling through FXBlt.
	Stenciling in general is done mapping all colors of source form
	to the stencil color and installing the appropriate source key.
	However, due to possible transparency we may have to install the
	color map as source map so that sourceForm gets mapped to a 32bit
	ARGB pixel value before the color combination is done. If we don't
	need translucency we can just use the regular color map (faster!)"
	| stencilColor screen patternWord |
	port isFXBlt ifFalse:[^self]. "Not appropriate for BitBlt"
	port sourceMap: nil; destMap: nil; colorMap: nil; sourceKey: nil.
	stencilColor _ self shadowColor ifNil:[aColor].
	stencilColor isColor ifFalse:[^self]. "No way"
	(stencilColor isTranslucent) ifFalse:[
		"If the paint color is not translucent we can use a simpler
		transformation going through a single color map."
		port sourceKey: 0. "The transparent source key"
		port fillPattern: stencilColor.
		port colorMap: (ColorMap colors: port fillColor).
		port fillColor: nil.
		^port combinationRule: Form over].
	(self depth >= 8) ifTrue:[
		"For transparent stenciling, things are more complicated.
		We need to install the transparent stencil color as source map
		so that all colors are mapped to the stencil color and afterwards
		blended with the destination."
		port sourceKey: 0. "The transparent source key"
		port fillPattern: stencilColor.
		port destMap: form colormapToARGB.
		port colorMap: form colormapFromARGB.
		port sourceMap: (ColorMap colors: (stencilColor bitPatternForDepth: 32)).
		port fillColor: nil.
		port combinationRule: Form blend.
		^self].
	"Translucent stenciling in < 8bit depth requires three parts,
	a color map, a fill pattern and the appropriate combination rule."
	port colorMap: (ColorMap colors: (Color maskingMap: form depth)).
	screen _ Color translucentMaskFor: stencilColor alpha depth: self depth.
	patternWord _ stencilColor pixelWordForDepth: self depth.
	port fillPattern: (screen collect: [:maskWord | maskWord bitAnd: patternWord]).
	port combinationRule: Form paint