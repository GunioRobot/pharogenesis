doModalDialog

	| savedArea |
	self resizeInitially.
	self resizeTo: 
		((self windowBox)
			align: self windowBox center
			with: Display boundingBox aboveCenter).
	savedArea _ Form fromDisplay: self windowBox.
	self displayEmphasized.
	self controller startUp.
	self release.
	savedArea displayOn: Display at: self windowOrigin.
