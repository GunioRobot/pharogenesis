flipBy: direction centerAt: aPoint
	| oldColors newForm |
	oldColors _ colors.
	self colors: nil.
	newForm _ super flipBy: direction centerAt: aPoint.
	self colors: oldColors.
	newForm colors: oldColors.
	^newForm 