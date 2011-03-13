addOptionalAnnotationsTo: window at: fractions plus: verticalOffset
	"Add an annotation pane to the window if preferences indicate a desire for it, and return the incoming verticalOffset plus the height of the added pane, if any"

	| aTextMorph divider delta |
	self wantsAnnotationPane ifFalse: [^ verticalOffset].
	aTextMorph := PluggableTextMorph 
		on: self
		text: #annotation 
		accept: #annotation:
		readSelection: nil
		menu: #annotationPaneMenu:shifted:.
	aTextMorph
		askBeforeDiscardingEdits: true;
		acceptOnCR: true;
		borderWidth: 0;
		hideScrollBarsIndefinitely.
	divider := BorderedSubpaneDividerMorph forBottomEdge.
	divider extent: 4@4; color: Color transparent; borderColor: #raised; borderWidth: 2.
	delta := self defaultAnnotationPaneHeight.
	window 
		addMorph: aTextMorph 
		fullFrame: (LayoutFrame 
				fractions: fractions 
				offsets: (0@verticalOffset corner: 0@(verticalOffset + delta - 2))).
	window 
		addMorph: divider
		fullFrame: (LayoutFrame 
				fractions: fractions 
				offsets: (0@(verticalOffset + delta - 2) corner: 0@(verticalOffset + delta))).
	^ verticalOffset + delta