graphicalTab
	self isCurrentlyGraphical
		ifTrue:
			[self changeTabGraphic]
		ifFalse:
			[self useGraphicalTab]