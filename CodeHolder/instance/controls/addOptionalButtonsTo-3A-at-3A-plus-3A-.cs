addOptionalButtonsTo: window at: fractions plus: verticalOffset
	"If the receiver wishes it, add a button pane to the window, and answer the verticalOffset plus the height added"

	| delta buttons divider |
	self wantsOptionalButtons ifFalse: [^verticalOffset].
	delta _ self defaultButtonPaneHeight.
	buttons _ self optionalButtonRow 
		color: (Display depth <= 8 ifTrue: [Color transparent] ifFalse: [Color gray alpha: 0.2]);
		borderWidth: 0.
	Preferences alternativeWindowLook ifTrue:[
		buttons color: Color transparent.
		buttons submorphsDo:[:m| m borderWidth: 2; borderColor: #raised].
	].
	divider _ BorderedSubpaneDividerMorph forBottomEdge.
	Preferences alternativeWindowLook ifTrue:[
		divider extent: 4@4; color: Color transparent; borderColor: #raised; borderWidth: 2.
	].
	window 
		addMorph: buttons
		fullFrame: (LayoutFrame 
				fractions: fractions 
				offsets: (0@verticalOffset corner: 0@(verticalOffset + delta - 1))).
	window 
		addMorph: divider
		fullFrame: (LayoutFrame 
				fractions: fractions 
				offsets: (0@(verticalOffset + delta - 1) corner: 0@(verticalOffset + delta))).
	^ verticalOffset + delta