addOptionalButtonsTo: window at: fractions plus: verticalOffset 
	"If the receiver wishes it, add a button pane to the window, and
	answer the verticalOffset plus the height added"
	| delta buttons divider |
	self wantsOptionalButtons
		ifFalse: [^ verticalOffset].
	delta := self defaultButtonPaneHeight.
	buttons := self optionalButtonRow color: Color white.
	divider := BorderedSubpaneDividerMorph forBottomEdge.
	divider extent: 4 @ 4;
				color: Color gray;
				borderColor: #simple;
				borderWidth: 1.
	window
		addMorph: buttons
		fullFrame: (LayoutFrame
				fractions: fractions
				offsets: (0 @ verticalOffset corner: 0 @ (verticalOffset + delta - 1))).
	window
		addMorph: divider
		fullFrame: (LayoutFrame
				fractions: fractions
				offsets: (0 @ (verticalOffset + delta - 1) corner: 0 @ (verticalOffset + delta))).
	^ verticalOffset + delta