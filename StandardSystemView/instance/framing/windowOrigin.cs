windowOrigin
	^ (self isCollapsed or: [labelFrame height = 0  "no label"])
		ifTrue: [self displayBox topLeft]
		ifFalse: [self displayBox topLeft - self labelOffset]