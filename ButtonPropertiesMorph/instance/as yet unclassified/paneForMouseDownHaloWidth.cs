paneForMouseDownHaloWidth

	^(self inARow: {
		self
			buildFakeSlider: #valueForMouseDownHaloWidth 
			selector: #adjustTargetMouseDownHaloSize:
			help: 'Drag in here to change the halo width' translated
	}) hResizing: #shrinkWrap
