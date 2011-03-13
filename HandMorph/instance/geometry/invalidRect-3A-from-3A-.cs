invalidRect: damageRect from: aMorph
	"Note that a change has occurred and record the given damage rectangle relative to the origin this hand's cache."
	hasChanged _ true.
	aMorph == self ifTrue:[^self].
	fullBounds == nil
		ifTrue: [damageRecorder recordInvalidRect: damageRect]
		ifFalse: [damageRecorder recordInvalidRect: (damageRect translateBy: fullBounds origin negated)].
