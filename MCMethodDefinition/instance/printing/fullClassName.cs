fullClassName
	^ self classIsMeta
		ifFalse: [self className]
		ifTrue: [self className, ' class']