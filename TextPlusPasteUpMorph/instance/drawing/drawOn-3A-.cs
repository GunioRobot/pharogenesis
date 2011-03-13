drawOn: aCanvas

	| clip rects |
	super drawOn: aCanvas.
	showPageBreaks == false ifTrue: [^self].

	clip _ aCanvas clipRect.
	rects _ self printer pageRectangles.
	rects do: [ :each |
		each bottom > clip bottom ifTrue: [^self].
		aCanvas 
			fillRectangle: (self left @ each bottom corner: self right @ each bottom + 1) 
			color: Color red
	].