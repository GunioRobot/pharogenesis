addMorph: aMorph fullFrame: aLayoutFrame

	| left right bottom top windowBorderWidth |
	windowBorderWidth _ self class borderWidth.

	left _ aLayoutFrame leftOffset ifNil: [0].
	right _ aLayoutFrame rightOffset ifNil: [0].

	bottom _ aLayoutFrame bottomOffset ifNil: [0].
	top _ aLayoutFrame topOffset ifNil: [0].
	
	aLayoutFrame rightFraction = 1 ifTrue: [aLayoutFrame rightOffset: right - windowBorderWidth].
	aLayoutFrame leftFraction = 0
		ifTrue: [aLayoutFrame leftOffset: left + windowBorderWidth]
		ifFalse: [aLayoutFrame leftOffset: left + ProportionalSplitterMorph splitterWidth].

	aLayoutFrame bottomFraction = 1 ifTrue: [aLayoutFrame bottomOffset: bottom - windowBorderWidth].
	aLayoutFrame topFraction = 0
		ifTrue: [aLayoutFrame topOffset: top]
		ifFalse: [aLayoutFrame topOffset: top + ProportionalSplitterMorph splitterWidth].
	
	(aMorph class name = #BrowserCommentTextMorph) ifTrue:
		[aLayoutFrame rightOffset: windowBorderWidth negated.
		aLayoutFrame leftOffset: windowBorderWidth.
		aLayoutFrame bottomOffset: windowBorderWidth negated.
		aLayoutFrame topOffset: (windowBorderWidth negated) + 4].
	
	super addMorph: aMorph fullFrame: aLayoutFrame.

	paneMorphs _ paneMorphs copyReplaceFrom: 1 to: 0 with: (Array with: aMorph).
	aMorph adoptPaneColor: self paneColor.
	aMorph borderWidth: 1; borderColor: Color lightGray; color: Color white.
	Preferences scrollBarsOnRight	"reorder panes so flop-out right-side scrollbar is visible"
		ifTrue: [self addMorphBack: aMorph].
		
	self addPaneSplitters