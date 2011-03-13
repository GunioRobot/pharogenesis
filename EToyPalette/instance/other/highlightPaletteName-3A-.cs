highlightPaletteName: aString

	self submorphsDo: [:m |
		(m isKindOf: StringButtonMorph) ifTrue: [
			(m contents beginsWith: aString)
				ifTrue: [m color: self buttonOnColor]
				ifFalse: [m color: self buttonOffColor]]].
