drawOn: aCanvas
	| nameForm |
	font _ self fontToUse.
	nameForm _ Form extent: bounds extent depth: 8.
	nameForm getCanvas drawString: contents at: 0@0 font: self fontToUse color: Color black.
	(bounds origin + 1) eightNeighbors do: [ :pt |
		aCanvas
			stencil: nameForm 
			at: pt
			color: self borderColor.
	].
	aCanvas
		stencil: nameForm 
		at: bounds origin + 1 
		color: color.


	
