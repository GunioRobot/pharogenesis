setLabelWidgetAllowance
	^ labelWidgetAllowance _ (Smalltalk isMorphic | Preferences optionalButtons)
		ifTrue:
			[super setLabelWidgetAllowance]
		ifFalse:
			[180]