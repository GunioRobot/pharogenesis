addLowerPanesTo: window at: nominalFractions with: editString

	| verticalOffset row innerFractions codePane infoPane infoHeight |

	row _ AlignmentMorph newColumn
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		layoutInset: 0;
		borderWidth: 1;
		borderColor: Color black;
		layoutPolicy: ProportionalLayout new.

	codePane _ PluggableTextMorph on: self text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	infoPane _ PluggableTextMorph on: self text: #infoViewContents accept: nil
			readSelection: nil menu: nil.
	verticalOffset _ 0.
	innerFractions _ 0@0 corner: 1@0.
">>not with this browser--- at least not yet ---
	verticalOffset _ self addOptionalAnnotationsTo: row at: innerFractions plus: verticalOffset.
	verticalOffset _ self addOptionalButtonsTo: row  at: innerFractions plus: verticalOffset.
<<<<"

	infoHeight _ 20.
	row 
		addMorph: (codePane borderWidth: 0)
		fullFrame: (
			LayoutFrame 
				fractions: (0@0 corner: 1@1) 
				offsets: (0@verticalOffset corner: 0@infoHeight negated)
		).
	row 
		addMorph: (SubpaneDividerMorph forTopEdge)
		fullFrame: (
			LayoutFrame 
				fractions: (0@1 corner: 1@1) 
				offsets: (0@infoHeight negated corner: 0@(1-infoHeight))
		).
	row 
		addMorph: (infoPane borderWidth: 0; hideScrollBarIndefinitely)
		fullFrame: (
			LayoutFrame 
				fractions: (0@1 corner: 1@1) 
				offsets: (0@(1-infoHeight) corner: 0@0)
		).
	window 
		addMorph: row
		frame: nominalFractions.

	row on: #mouseEnter send: #paneTransition: to: window.
	row on: #mouseLeave send: #paneTransition: to: window.

