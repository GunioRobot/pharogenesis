initializeToStandAlone
	self initialize.
	self removeEverything; pageSize: 360@228; color: (Color gray: 0.9).
	self borderWidth: 1; borderColor: Color black.
	self beSticky.
	self showPageControls; insertPage.
	^ self