newSliderMorph
	"Answer a new morph for the slider."

	|slider|
	slider := UITheme builder
		newBracketSliderFor: self
		getValue: #value
		setValue: #value:
		min: 0
		max: 100
		quantum: 1
		getEnabled: #enabled
		help: nil.
	slider fillStyle: self defaultSliderFillStyle.
	^slider