addLowerMorphicViews: views andButtons: buttons to: topWindow offset: offset 
	| row verticalOffset innerFractions |
	row _ AlignmentMorph newColumn hResizing: #spaceFill;
				 vResizing: #spaceFill;
				 layoutInset: 0;
				 borderWidth: 1;
				 borderColor: Color black;
				 layoutPolicy: ProportionalLayout new.
	verticalOffset _ 0.
	innerFractions _ 0 @ 0 corner: 1 @ 0.
	verticalOffset _ self
				addMorphicButtons: buttons
				to: row
				at: innerFractions
				plus: verticalOffset.
	self includeStatusPane ifTrue: [
	verticalOffset _ self
				addMorphicStatusPaneTo: row
				from: views
				at: innerFractions
				plus: verticalOffset].
	self
		addMorphicTextPaneTo: row
		from: views
		at: innerFractions
		plus: verticalOffset.
	topWindow
		addMorph: row
		frame: (0 @ offset extent: 1 @ (1 - offset)).
	row
		on: #mouseEnter
		send: #paneTransition:
		to: topWindow.
	row
		on: #mouseLeave
		send: #paneTransition:
		to: topWindow