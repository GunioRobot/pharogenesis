update: what
	what ifNil:[^self].
	what == getLabelSelector ifTrue: [
		self label: (model perform: getLabelSelector)].
	what == getColorSelector ifTrue: [
		color := (model perform: getColorSelector).
		self onColor: color offColor: color.
		self changed.
	].
	what == getStateSelector ifTrue:[
		self getModelState
			ifTrue: [self color: onColor]
			ifFalse: [self color: offColor].
	].
	what == getEnabledSelector ifTrue:[^self enabled: (model perform: getEnabledSelector)].