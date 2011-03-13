collapseOrExpand
	"Collapse or expand the window, depending on existing state"
	| cf |
	isCollapsed
		ifTrue: 
			["Expand -- restore panes to morphics structure"
			isCollapsed _ false.
			self activate.  "Bring to frint first"
			Preferences collapseWindowsInPlace
				ifTrue: 
					[fullFrame _ fullFrame align: fullFrame topLeft with: self getBoundsWithFlex topLeft]
				ifFalse:
					[collapsedFrame _ self getBoundsWithFlex].
			collapseBox ifNotNil: [collapseBox setBalloonText: 'collapse this window'].
			self setBoundsWithFlex: fullFrame.
			paneMorphs reverseDo: 
					[:m |  self addMorph: m unlock.
					self world startSteppingSubmorphsOf: m].
			self addPaneSplitters]
		ifFalse: 
			["Collapse -- remove panes from morphics structure"
			isCollapsed _ true.
			fullFrame _ self getBoundsWithFlex.
			"First save latest fullFrame"
			paneMorphs do: [:m | m delete; releaseCachedState].
			self removePaneSplitters.
			self removeCornerGrips.
			model modelSleep.
			cf _ self getCollapsedFrame.
			(collapsedFrame isNil and: [Preferences collapseWindowsInPlace not]) ifTrue:
				[collapsedFrame _ cf].
			self setBoundsWithFlex: cf.
			collapseBox ifNotNil: [collapseBox setBalloonText: 'expand this window'].
			expandBox ifNotNil: [expandBox setBalloonText: 'expand to full screen']].
	self layoutChanged