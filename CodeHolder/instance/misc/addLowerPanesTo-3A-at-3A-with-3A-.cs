addLowerPanesTo: window at: nominalFractions with: editString

	| verticalOffset row innerFractions |

	row _ AlignmentMorph newColumn
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		layoutInset: 0;
		borderWidth: 1;
		borderColor: Color black;
		layoutPolicy: ProportionalLayout new.

	verticalOffset _ 0.
	innerFractions _ 0@0 corner: 1@0.
	verticalOffset _ self addOptionalAnnotationsTo: row at: innerFractions plus: verticalOffset.
	verticalOffset _ self addOptionalButtonsTo: row  at: innerFractions plus: verticalOffset.

	row 
		addMorph: ((self buildMorphicCodePaneWith: editString) borderWidth: 0)
		fullFrame: (
			LayoutFrame 
				fractions: (innerFractions withBottom: 1) 
				offsets: (0@verticalOffset corner: 0@0)
		).
	window 
		addMorph: row
		frame: nominalFractions.

	row on: #mouseEnter send: #paneTransition: to: window.
	row on: #mouseLeave send: #paneTransition: to: window.