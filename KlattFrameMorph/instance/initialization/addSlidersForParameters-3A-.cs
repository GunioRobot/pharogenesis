addSlidersForParameters: params
	| left right container current slider |
	params size < 10
		ifTrue: [left _ right _ self]
		ifFalse: [container _ AlignmentMorph new color: self color; orientation: #horizontal.
				left _ container clone orientation: #vertical.
				right _ left clone.
				container addMorphBack: left; addMorphBack: right.
				self addMorphBack: container].
	params do: [ :each |
		current _ current == left ifTrue: [right] ifFalse: [left].
		slider _ self newSliderNamed: each min: (KlattFrame minimumForParameter: each) max: (KlattFrame maximumForParameter: each).
		slider setBalloonText: (KlattFrame descriptionForParameter: each).
		current addMorphBack: slider]