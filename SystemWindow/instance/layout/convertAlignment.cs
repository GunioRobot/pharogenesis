convertAlignment
	| frame |
	self layoutPolicy: ProportionalLayout new.
	(paneMorphs == nil or:[paneRects == nil or:[paneMorphs size ~= paneRects size]]) ifFalse:[
		self addLabelArea.
		self putLabelItemsInLabelArea.
		self setFramesForLabelArea.
		paneMorphs with: paneRects do:[:m :r|
			frame _ LayoutFrame new.
			frame leftFraction: r left; rightFraction: r right; topFraction: r top; bottomFraction: r bottom.
			m layoutFrame: frame.
			m hResizing: #spaceFill; vResizing: #spaceFill.
		].
	].
	labelArea ifNil: [
		self addLabelArea.
		self putLabelItemsInLabelArea.
		self setFramesForLabelArea.
		paneMorphs ifNotNil: [
			paneMorphs do: [:m |
				frame := m layoutFrame ifNil: [LayoutFrame new].
				frame topOffset: (frame topOffset ifNil: [0]) - self labelHeight.
				(frame bottomFraction ~= 1.0) ifTrue:
					[ frame bottomOffset: (frame bottomOffset ifNil: [0]) - self labelHeight ].
			].
		].
	].
	label ifNotNil:[
		frame _ LayoutFrame new.
		frame leftFraction: 0.5; topFraction: 0; leftOffset: label width negated // 2.
		label layoutFrame: frame].
	collapseBox ifNotNil:[
		frame _ LayoutFrame new.
		frame rightFraction: 1; topFraction: 0; rightOffset: -1; topOffset: 1.
		collapseBox layoutFrame: frame].
	stripes ifNotNil:[
		frame _ LayoutFrame new.
		frame leftFraction: 0; topFraction: 0; rightFraction: 1;
				leftOffset: 1; topOffset: 1; rightOffset: -1.
		stripes first layoutFrame: frame.
		stripes first height: self labelHeight - 2.
		stripes first hResizing: #spaceFill.
		frame _ LayoutFrame new.
		frame leftFraction: 0; topFraction: 0; rightFraction: 1;
				leftOffset: 3; topOffset: 3; rightOffset: -3.
		stripes last layoutFrame: frame.
		stripes last height: self labelHeight - 6.
		stripes last hResizing: #spaceFill].
	menuBox ifNotNil:[
		frame _ LayoutFrame new.
		frame leftFraction: 0; leftOffset: 19; topFraction: 0; topOffset: 1.
		menuBox layoutFrame: frame].
	closeBox ifNotNil:[
		frame _ LayoutFrame new.
		frame leftFraction: 0; leftOffset: 4; topFraction: 0; topOffset: 1.
		closeBox layoutFrame: frame].
