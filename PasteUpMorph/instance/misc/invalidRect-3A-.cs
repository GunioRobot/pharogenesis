invalidRect: damageRect
	"Clip damage reports to my bounds, since drawing is clipped to my bounds."

	self isWorldMorph
		ifTrue: [self damageRecorder ifNotNil:
					[self damageRecorder recordInvalidRect: damageRect]]
		ifFalse: [super invalidRect: (damageRect intersect: bounds)]
