paneForMouseOverHaloWidth

	^(self inARow: {
		self
			buildFakeSlider: #valueForMouseOverHaloWidth
			selector: #adjustTargetMouseOverHaloSize:
			help: 'Drag in here to change the halo width' translated
	}) hResizing: #shrinkWrap
