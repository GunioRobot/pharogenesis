durableOpenMenu 
	| colorPattern |
	colorPattern _ #(blue lightGreen lightYellow lightMagenta  lightOrange lightCyan) asOrderedCollection.
	colorPattern add: Project someInstance backgroundColorForMvcProject.
	colorPattern add: Project someInstance backgroundColorForMorphicProject.
	colorPattern add: #orange.
	Utilities windowFromMenu: self openMenu target: self title: 'Openers'
		colorPattern: colorPattern