setLabelWidgetAllowance
	^ labelWidgetAllowance := Preferences optionalButtons
				ifTrue: [super setLabelWidgetAllowance]
				ifFalse: [180]