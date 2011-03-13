addOptionalButtonsTo: window at: fractions plus: verticalOffset 
	"Add button panes to the window. A row of custom
	debugger-specific buttons (Proceed, Restart, etc.) is always
	added, and if optionalButtons is in force, then the standard
	code-tool buttons are also added. Answer the verticalOffset
	plus the height added."
	| delta buttons anOffset |
	anOffset := (Preferences optionalButtons
					and: [Preferences extraDebuggerButtons])
				ifTrue: [super
						addOptionalButtonsTo: window
						at: fractions
						plus: verticalOffset]
				ifFalse: [verticalOffset].
	buttons := self customButtonRow.
	delta := self defaultButtonPaneHeight max: (buttons minExtent y + 1).
	buttons color: Color white; borderWidth: 0.
	window
		addMorph: buttons
		fullFrame: (LayoutFrame
				fractions: fractions
				offsets: (0 @ anOffset corner: 0 @ (anOffset + delta - 1))).
	^ anOffset + delta