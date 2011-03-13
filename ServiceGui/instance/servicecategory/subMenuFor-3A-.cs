subMenuFor: aServiceCategory 
	self pushMenu.
	aServiceCategory enabledServices
		ifEmpty: [self menuItemFor: ServiceAction new].
	aServiceCategory enabledServices
		doWithIndex: [:each :i | self n: i. self menuItemFor: each].
	^ self popMenu