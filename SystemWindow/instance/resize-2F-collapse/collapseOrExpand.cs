collapseOrExpand
	isCollapsed
		ifTrue: 
			["Expand -- restore panes to morphics structure"
			isCollapsed _ false.
			collapsedFrame _ self getBoundsWithFlex.
			"First save latest collapsedFrame"
			self setBoundsWithFlex: fullFrame.
			paneMorphs
				reverseDo: 
					[:m | 
					self addMorph: m.
					self world startSteppingSubmorphsOf: m].
			self activate "-- mainly for findWindow"]
		ifFalse: 
			["Collapse -- remove panes from morphics structure"
			isCollapsed _ true.
			fullFrame _ self getBoundsWithFlex.
			"First save latest fullFrame"
			paneMorphs do: [:m | m delete; releaseCachedState].
			model modelSleep.
			collapsedFrame _ (RealEstateAgent assignCollapseFrameFor: self).
						
			self setBoundsWithFlex: collapsedFrame].
	self layoutChanged