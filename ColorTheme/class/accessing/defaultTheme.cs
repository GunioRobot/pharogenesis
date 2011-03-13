defaultTheme
	Smalltalk
		at: #YellowSmallLandColorTheme
		ifPresent: [:yellowSmallLandColorTheme | ^ yellowSmallLandColorTheme].
	^ (self allSubclasses
		select: [:each | each subclasses isEmpty]) anyOne