initializeLabelArea
	"Initialize the label area (titlebar) for the window."
	label := LabelStringMorph new
				contents: labelString;
				font: Preferences windowTitleFont
				emphasis: (Preferences windowTitleFont isTTCFont ifTrue: [0] ifFalse: [1]);
				mySystemWindow: self.
	"Add collapse box so #labelHeight will work"
	collapseBox := self createCollapseBox.
	stripes := Array
				with: (RectangleMorph newBounds: bounds)
				with: (RectangleMorph newBounds: bounds).
	"see extent:"
	self addLabelArea.
	labelArea
		addMorph: (stripes first borderWidth: 1).
	labelArea
		addMorph: (stripes second borderWidth: 2).
	self setLabelWidgetAllowance.
	self addCloseBox.
	self addMenuControl.
	labelArea addMorph: label.
	self wantsExpandBox
		ifTrue: [self addExpandBox].
	labelArea addMorph: collapseBox.
	self setFramesForLabelArea.
	Preferences clickOnLabelToEdit
		ifTrue: [label
				on: #mouseDown
				send: #relabel
				to: self].
	Preferences noviceMode
		ifTrue: [closeBox
				ifNotNil: [closeBox setBalloonText: 'close window' translated].
			menuBox
				ifNotNil: [menuBox setBalloonText: 'window menu' translated].
			collapseBox
				ifNotNil: [collapseBox setBalloonText: 'collapse/expand window' translated]].
