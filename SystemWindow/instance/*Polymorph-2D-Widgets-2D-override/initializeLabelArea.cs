initializeLabelArea
	"Initialize the label area (titlebar) for the window."
	
	label := self theme windowLabelFor: self.
	"Add default inital boxes"
	collapseBox := self createCollapseBox. "Add collapse box so #labelHeight will work"
	closeBox := self createCloseBox.
	self wantsExpandBox ifTrue: [
		expandBox := self createExpandBox.
		self setExpandBoxBalloonText].
	menuBox := self createMenuBox.
	stripes := Array
						with: (RectangleMorph newBounds: bounds)
						with: (RectangleMorph newBounds: bounds).
	self addLabelArea.
	labelArea
		goBehind;
		maxCellSize: self boxExtent.
	self replaceBoxes.
	Preferences clickOnLabelToEdit
		ifTrue: [label
					on: #mouseDown
					send: #relabel
					to: self].
	labelArea fillStyle: self activeTitleFillStyle.