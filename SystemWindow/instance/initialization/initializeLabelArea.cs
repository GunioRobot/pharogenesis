initializeLabelArea
	"Initialize the label area (titlebar) for the window."
	label _ StringMorph new contents: labelString;
						 font: Preferences windowTitleFont emphasis: 0.
			"Add collapse box so #labelHeight will work"
			collapseBox _ self createCollapseBox.
			stripes _ Array
						with: (RectangleMorph newBounds: bounds)
						with: (RectangleMorph newBounds: bounds).
			"see extent:"
			self addLabelArea.
			self setLabelWidgetAllowance.
			self addCloseBox.
			self addMenuControl.
			labelArea addMorphBack: (Morph new extent: self class borderWidth @ 0).
			labelArea addMorphBack: label.
			self wantsExpandBox
				ifTrue: [self addExpandBox].
			labelArea addMorphBack: collapseBox.
			self setFramesForLabelArea.
			Preferences clickOnLabelToEdit
				ifTrue: [label
						on: #mouseDown
						send: #relabel
						to: self].
			Preferences noviceMode
				ifTrue: [closeBox
						ifNotNil: [closeBox setBalloonText: 'close window'].
					menuBox
						ifNotNil: [menuBox setBalloonText: 'window menu'].
					collapseBox
						ifNotNil: [collapseBox setBalloonText: 'collapse/expand window']].
