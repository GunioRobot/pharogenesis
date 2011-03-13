initialize
	"Initialize a system window. Add label, stripes, etc., if desired"
	super initialize.
	allowReframeHandles _ true.
	labelString ifNil: [labelString _ 'Untitled Window'].
	isCollapsed _ false.
	activeOnlyOnTop _ true.
	paneMorphs _ Array new.
	borderColor _ Color lightGray.
	borderWidth _ 1.
	self color: Color lightGray lighter lighter lighter.
	self layoutPolicy: ProportionalLayout new.
	
	label _ StringMorph new contents: labelString;
						 font: Preferences windowTitleFont emphasis: 1.
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
				
	self addCornerGrips.

	self extent: 300 @ 200.
	mustNotClose _ false.
	updatablePanes _ Array new.
		
	Preferences menuAppearance3d
		ifTrue: [
			self
				addDropShadow;
				shadowColor: (TranslucentColor r: 0.0 g: 0.0 b: 0.0 alpha: 0.333);
				shadowOffset: 1@1.
		].
					