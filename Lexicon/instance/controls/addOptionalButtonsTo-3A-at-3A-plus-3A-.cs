addOptionalButtonsTo: window at: fractions plus: verticalOffset
	"In this case we may actually add TWO rows of buttons."

	| delta buttons divider anOffset |
	anOffset := Preferences optionalButtons
		ifTrue:
			[super addOptionalButtonsTo: window at: fractions plus: verticalOffset]
		ifFalse:
			[verticalOffset].
	delta := self defaultButtonPaneHeight.
	buttons := self customButtonRow.
	buttons	 color: (Display depth <= 8 ifTrue: [Color transparent] ifFalse: [Color gray alpha: 0.2]);
		borderWidth: 0.
	buttons color: Color transparent.
	buttons submorphsDo:[:m | m borderWidth: 2; borderColor: #raised].
	divider := BorderedSubpaneDividerMorph forBottomEdge.
	divider extent: 4@4; color: Color transparent; borderColor: #raised; borderWidth: 2.
	window 
		addMorph: buttons
		fullFrame: (LayoutFrame 
				fractions: fractions 
				offsets: (0@anOffset corner: 0@(anOffset + delta - 1))).
	window 
		addMorph: divider
		fullFrame: (LayoutFrame 
				fractions: fractions 
				offsets: (0@(anOffset + delta - 1) corner: 0@(anOffset + delta))).
	^ anOffset + delta