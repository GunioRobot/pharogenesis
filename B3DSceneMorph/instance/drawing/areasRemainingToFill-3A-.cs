areasRemainingToFill: aRectangle
	(color isColor and:[color isOpaque]) ifFalse: [^ Array with: aRectangle].
	^ aRectangle areasOutside: self bounds