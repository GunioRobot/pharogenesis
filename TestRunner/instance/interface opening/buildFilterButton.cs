buildFilterButton
	| filterButton |
	filterButton _ PluggableButtonMorph
				on: self
				getState: nil
				action: #setFilter
				label: #filterButtonLabel.
	filterButton 
		 hResizing: #spaceFill;
		 vResizing: #spaceFill;
		 useRoundedCorners.
	filterButton onColor: self runButtonColor offColor: self runButtonColor.
	^ filterButton