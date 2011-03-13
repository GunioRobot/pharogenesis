minimizeOrRestore
	"Collapse or expand the window, depending on existing state"
	
	|mc|
	isCollapsed
		ifTrue: ["Expand -- restore panes to morphics structure"
			Preferences windowAnimation ifTrue: [self animateRestoreFromMinimized].
			isCollapsed := false.
			"Bring to front first"
			self
				setBoundsWithFlex: fullFrame;
				comeToFront;
				show.
			mc := self modalChild.
			paneMorphs reverseDo: [:m | 
				mc ifNil: [m unlock].
				self addMorph: m.
				self world startSteppingSubmorphsOf: m].
			self activate]
		ifFalse: ["Collapse -- remove panes from morphics structure"
			isCollapsed := true.
			fullFrame := self getBoundsWithFlex.
			"First save latest fullFrame"
			paneMorphs
				do: [:m | m delete; releaseCachedState].
			model modelSleep.
			self
				setBoundsWithFlex: (-100@-100 extent: 2@2); "place offscreen"
				hide.
			Preferences windowAnimation ifTrue: [self animateMinimize].
			self isActive ifTrue: [
				self world navigateVisibleWindowForward]].
	self layoutChanged