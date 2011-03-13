addOptionalAnnotationsTo: window at: fractions plus: verticalOffset
	"Add an annotation pane to the window if preferences indicate a desire for it, and return the incoming verticalOffset plus the height of the added pane, if any"

	| aTextMorph divider delta |
	self wantsAnnotationPane ifFalse: [^ verticalOffset].
	aTextMorph _ PluggableTextMorph 
		on: self
		text: #annotation 
		accept: nil
		readSelection: nil
		menu: #annotationPaneMenu:shifted:.
	aTextMorph
		askBeforeDiscardingEdits: false;
		borderWidth: 0;
		hideScrollBarIndefinitely.
	divider _ SubpaneDividerMorph forBottomEdge.
	delta _ self defaultAnnotationPaneHeight.
	window 
		addMorph: aTextMorph 
		fullFrame: (LayoutFrame 
				fractions: fractions 
				offsets: (0@verticalOffset corner: 0@(verticalOffset + delta - 1))).
	window 
		addMorph: divider
		fullFrame: (LayoutFrame 
				fractions: fractions 
				offsets: (0@(verticalOffset + delta - 1) corner: 0@(verticalOffset + delta))).
	^ verticalOffset + delta