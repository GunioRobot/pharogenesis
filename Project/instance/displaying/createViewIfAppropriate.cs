createViewIfAppropriate

	ProjectViewOpenNotification signal ifTrue: [
		Preferences projectViewsInWindows ifTrue: [
			(ProjectViewMorph newProjectViewInAWindowFor: self) openInWorld
		] ifFalse: [
			(ProjectViewMorph on: self) openInWorld		"but where??"
		].
	].
