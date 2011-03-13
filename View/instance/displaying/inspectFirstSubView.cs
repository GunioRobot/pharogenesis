inspectFirstSubView
	subViews notNil ifTrue:
		[subViews size > 0 ifTrue:
			[(subViews at: 1) inspect]]