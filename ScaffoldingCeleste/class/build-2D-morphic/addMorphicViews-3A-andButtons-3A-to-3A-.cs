addMorphicViews: views andButtons: buttons to: topWindow 
	topWindow
		addMorph: (views at: #categoryList)
		frame: (0.0 @ 0.0 extent: 0.2 @ 0.25).

	topWindow
		addMorph: (views at: #tocEntryList)
		frame: (0.2 @ 0.0 extent: 0.8 @ 0.25).
	self
		addLowerMorphicViews: views
		andButtons: buttons
		to: topWindow
		offset: 0.25 