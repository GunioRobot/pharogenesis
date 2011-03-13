menu: aMenu
	self isEmpty ifFalse:
		[self addActionsToMenu: aMenu.
		self addServicesToMenu: aMenu].
	^ aMenu