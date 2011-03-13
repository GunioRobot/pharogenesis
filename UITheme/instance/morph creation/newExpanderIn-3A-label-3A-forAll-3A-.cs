newExpanderIn: aThemedMorph label: aString forAll: controls
	"Answer an expander with the given label and controls."

	|answer|
	answer := ExpanderMorph new
		font: self menuFont;
		titleText: aString;
		fillStyle: Color white.
	controls do: [:m |
		answer addMorphBack: m].
	^answer