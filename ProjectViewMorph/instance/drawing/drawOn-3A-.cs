drawOn: aCanvas

	| font projectName nameForm rectForName |

	self ensureImageReady.
	super drawOn: aCanvas.
	self isEditingName ifTrue: [^self].

	font _ self fontForName.
	projectName _ self safeProjectName.
	nameForm _ (StringMorph contents: projectName font: font) imageForm.
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


	
