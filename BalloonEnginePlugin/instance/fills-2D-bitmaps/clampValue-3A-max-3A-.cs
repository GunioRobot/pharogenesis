clampValue: value max: maxValue

	self inline: true.
	value < 0 
		ifTrue:[^0]
		ifFalse:[value >= maxValue 
					ifTrue:[^maxValue-1]
					ifFalse:[^value]]