release
	self isCollapsed ifTrue: [savedSubViews do: [:v | v release]].
	super release