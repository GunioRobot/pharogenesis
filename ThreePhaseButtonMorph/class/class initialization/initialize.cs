initialize
	"ThreePhaseButtonMorph initialize"
	| extent inset |
	extent _ 12@12.
	inset _ 3.

	#('CheckBoxOff' 'CheckBoxOn' 'CheckBoxPressed') do: [:button |
		| f r |
		f _ ColorForm extent: extent depth: 1.
		f colors: {Color transparent. Color black}.
		f borderWidth: 1.
		r _ f boundingBox insetBy: inset.
		button = 'CheckBoxPressed' ifTrue: [f border: r width: 1].
		button = 'CheckBoxOn' ifTrue: [f fillBlack: r].
		ScriptingSystem saveForm: f atKey: button].

	#('RadioButtonOff' 'RadioButtonOn' 'RadioButtonPressed') do: [:button |
		| f r c |
		f _ ColorForm extent: extent depth: 1.
		f colors: {Color transparent. Color black}.
		r _ f boundingBox.
		c _ f getCanvas.
		c frameOval: r color: Color black.
		r _ r insetBy: inset.
		button = 'RadioButtonPressed' ifTrue:
			[c frameOval: r color: Color black].
		button = 'RadioButtonOn' ifTrue:
			[c fillOval: r color: Color black].
		ScriptingSystem saveForm: f atKey: button]