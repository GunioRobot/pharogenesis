morphicWindow
	"TestRunner new openAsMorph"
	| upperRow lowerPanes fracYRatio divider window |
	window _ SystemWindow labelled: self windowLabel.
	window model: self.
	upperRow _ self buildUpperControls.
	lowerPanes _ self buildLowerPanes.
	fracYRatio _ 0.25.
	window
		addMorph: upperRow
		fullFrame: (LayoutFrame fractions: (0 @ 0 extent: 1 @ fracYRatio) offsets: (0@0 corner: 0@0)).
	divider _ BorderedSubpaneDividerMorph forBottomEdge.
	Preferences alternativeWindowLook
		ifTrue: [divider hResizing: #spaceFill;
				 color: Color transparent;
				 borderColor: #raised;
				 borderWidth: 1].
	window
		addMorph: divider
		fullFrame: (LayoutFrame
				fractions: (0 @ fracYRatio corner: 1 @ fracYRatio)
				offsets: (0 @ 0 corner: 0 @ 2)).

	window
		addMorph: lowerPanes
		fullFrame: (LayoutFrame fractions: (0 @ fracYRatio extent: 1 @ (1 - fracYRatio)) offsets: (0@0 corner: 0@0)).
	self refreshWindow.
	window extent: 460 @ 400.
	^window