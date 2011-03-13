stringColorToUse
	"Answer the state dependent color to use for drawing text."
	
	^self isEnabled
		ifTrue: [self isSelected
					ifTrue: [((self selectionTextColor luminance - self selectionFillStyle asColor luminance) abs < 0.6)
								ifTrue: [self selectionFillStyle asColor darker contrastingColor]
								ifFalse: [self selectionTextColor]]
					ifFalse: [((self color luminance - self owner paneColor luminance) abs < 0.3)
								ifTrue: [self owner paneColor contrastingColor]
								ifFalse: [self color]]]
		ifFalse: [((self color luminance - self owner paneColor luminance) abs < 0.3)
					ifTrue: [self owner color contrastingColor]
					ifFalse: [self color]]