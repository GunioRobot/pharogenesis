paneForRepeatingInterval

	^(self 
		inAColumn: {
			self
				buildFakeSlider: #valueForRepeatingInterval
				selector: #adjustTargetRepeatingInterval:
				help: 'Drag in here to change how often the button repeats while the mouse is down' translated
		}
		 named: #paneForRepeatingInterval
	) hResizing: #shrinkWrap
