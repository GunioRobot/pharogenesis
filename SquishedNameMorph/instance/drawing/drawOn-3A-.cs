drawOn: aCanvas

	| font stringToShow nameForm rectForName |

	super drawOn: aCanvas.
	self isEditingName ifTrue: [^self].

	font _ self fontForName.
	stringToShow _ self stringToShow.
	nameForm _ (StringMorph contents: stringToShow font: font) imageForm.
	nameForm _ nameForm scaledToSize: (self extent - (4@2) min: nameForm extent).
	rectForName _ self bottomLeft + 
			(self width - nameForm width // 2 @ (nameForm height + 2) negated)
				extent: nameForm extent.
	rectForName topLeft eightNeighbors do: [ :pt |
		aCanvas
			stencil: nameForm 
			at: pt
			color: self colorAroundName.
	].
	aCanvas
		stencil: nameForm 
		at: rectForName topLeft 
		color: Color black.


	
