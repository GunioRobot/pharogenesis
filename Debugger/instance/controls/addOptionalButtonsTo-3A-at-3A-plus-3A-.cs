addOptionalButtonsTo: window at: fractions plus: verticalOffset
	"Add button panes to the window.  A row of custom debugger-specific buttons (Proceed, Restart, etc.) is always added, and if optionalButtons is in force, then the standard code-tool buttons are also added.  Answer the verticalOffset plus the height added."

	| delta buttons divider anOffset |
	anOffset _ (Preferences optionalButtons and: [Preferences extraDebuggerButtons])
		ifTrue:
			[super addOptionalButtonsTo: window at: fractions plus: verticalOffset]
		ifFalse:
			[verticalOffset].

	delta _ self defaultButtonPaneHeight.
	buttons _ self customButtonRow.
	buttons	 color: (Display depth <= 8 ifTrue: [Color transparent] ifFalse: [Color gray alpha: 0.2]);
		borderWidth: 0.
	Preferences alternativeWindowLook ifTrue:
		[buttons color: Color transparent.
		buttons submorphsDo:[:m | m borderWidth: 2; borderColor: #raised]].
	divider _ BorderedSubpaneDividerMorph forBottomEdge.
	Preferences alternativeWindowLook ifTrue:
		[divider extent: 4@4; color: Color transparent; borderColor: #raised; borderWidth: 2].
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