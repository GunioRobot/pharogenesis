addSlidersForParameters: params
	| left right container current slider |
	params size < 10
		ifTrue: [left := right := self]
		ifFalse: [container := AlignmentMorph new color: self color; listDirection: #leftToRight.
				left := container clone listDirection: #topToBottom.
				right := left clone.
				container addMorphBack: left; addMorphBack: right.
				self addMorphBack: container].
	params do: [ :each |
		current := current == left ifTrue: [right] ifFalse: [left].
		slider := self newSliderNamed: each min: (KlattFrame minimumForParameter: each) max: (KlattFrame maximumForParameter: each).
		slider setBalloonText: (KlattFrame descriptionForParameter: each).
		current addMorphBack: slider]