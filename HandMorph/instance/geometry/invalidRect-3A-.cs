invalidRect: damageRect
	"Extend damage to cover drop-shadow when carrying morphs."

	| r |
	fullBounds == nil
		ifTrue: [damageRecorder recordInvalidRect: damageRect]
		ifFalse: [damageRecorder recordInvalidRect: (damageRect translateBy: fullBounds origin negated)].
	submorphs isEmpty
		ifTrue: [r _ damageRect]
		ifFalse: [r _ damageRect topLeft extent: damageRect extent + self shadowOffset].
	super invalidRect: r.
