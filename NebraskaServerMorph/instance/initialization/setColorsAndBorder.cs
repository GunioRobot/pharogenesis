setColorsAndBorder
	| worldColor c |
	c := ((Preferences menuColorFromWorld and: [Display depth > 4]) 
				and: [(worldColor := self currentWorld color) isColor]) 
					ifTrue: 
						[worldColor luminance > 0.7 
							ifTrue: [worldColor mixed: 0.8 with: Color black]
							ifFalse: [worldColor mixed: 0.4 with: Color white]]
					ifFalse: [Preferences menuColor]. 
	self color: c.
	self borderColor: #raised.
	self borderWidth: Preferences menuBorderWidth.
	self useRoundedCorners