invalidRect: damageRect

	self == World
		ifTrue: [self damageRecorder ifNotNil:
					[self damageRecorder recordInvalidRect: damageRect]]
		ifFalse: [super invalidRect: (damageRect intersect: bounds)]
