makeParameterSlider
	| menu choice s |
	menu := CustomMenu new title: 'Parameter?'.
	self sliderParameters do: [:rec | menu add: rec first action: rec].
	choice := menu startUp.
	choice ifNil: [^self].
	s := self 
				newSliderForParameter: choice first
				target: self
				min: (choice second)
				max: (choice third)
				description: (choice fourth).
	self world activeHand attachMorph: s