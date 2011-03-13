collapseOrExpand
	"Collapse or expand the window, depending on existing state.
	Use the taskbar if present, otherwise do as normal."
	
	| cf |
	self isTaskbarPresent ifTrue: [^self minimizeOrRestore].
	isCollapsed
		ifTrue: 
			["Expand -- restore panes to morphics structure"
			isCollapsed := false.
			self activate.  "Bring to frint first"
			Preferences collapseWindowsInPlace
				ifTrue: 
					[fullFrame := fullFrame align: fullFrame topLeft with: self getBoundsWithFlex topLeft]
				ifFalse:
					[collapsedFrame := self getBoundsWithFlex].
			collapseBox ifNotNil: [collapseBox setBalloonText: 'collapse this window'].
			self setBoundsWithFlex: fullFrame.
			paneMorphs reverseDo: 
					[:m |  self addMorph: m unlock.
					self world startSteppingSubmorphsOf: m].
			self
				addPaneSplitters;
				addGripsIfWanted]
		ifFalse: 
			["Collapse -- remove panes from morphics structure"
			isCollapsed := true.
			fullFrame := self getBoundsWithFlex.
			"First save latest fullFrame"
			paneMorphs do: [:m | m delete; releaseCachedState].
			self removePaneSplitters.
			self removeGrips.
			model modelSleep.
			cf := self getCollapsedFrame.
			(collapsedFrame isNil and: [Preferences collapseWindowsInPlace not]) ifTrue:
				[collapsedFrame := cf].
			self setBoundsWithFlex: cf.
			collapseBox ifNotNil: [collapseBox setBalloonText: 'expand this window'].
			expandBox ifNotNil: [expandBox setBalloonText: 'expand to full screen']].
	self layoutChanged