collapseOrExpand
	isCollapsed
	ifTrue:
		["Expand -- restore panes to morphics structure"
		isCollapsed _ false.
		paneMorphs reverseDo: [:m | self addMorph: m].
		super bounds: fullFrame.
		self activate "-- mainly for findWindow"]
	ifFalse:
		["Collapse -- remove panes from morphics structure"
		isCollapsed _ true.
		paneMorphs do: [:m | m delete; releaseCachedState].
		collapsedFrame
			ifNil:	[self extent: (label width + 50) @ (self labelHeight + 2).
					self position: (RealEstateAgent assignCollapsePointFor: self)]
			ifNotNil: [super bounds: collapsedFrame]]