morph
	| morph |
	morph := PluggableButtonMorph
		on: self
		getState: #isSelected
		action: #push
		label: #labelMorph.
	morph 
		hResizing: #spaceFill;
		vResizing: #spaceFill.
	^ morph