mouseOverHalosString
	^ self wantsMouseOverHalos
		ifTrue:
			['stop using mouse-over halos']
		ifFalse:
			['start using mouse-over halos']
