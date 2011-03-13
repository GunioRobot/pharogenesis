dropTargetFor: aMorph event: evt
	"Return the morph that the given morph is to be dropped onto.  Return nil if we must repel the morph.  Return the world, if no other morph wants the dropping morph."

	| root coreSample |
	root _ nil.
	owner submorphsReverseDo: [:m |
		((m fullContainsPoint: evt cursorPoint) and:
		 [(m isKindOf: HaloMorph) not]) ifTrue: [root _ m]].
	root == nil ifTrue: [^ self world].
	coreSample _ root morphsAt: evt cursorPoint.
	coreSample do:
		[:m |
			(m repelsMorph: aMorph event: evt) ifTrue: ["self halt: 'Repel by ', m externalName." ^ nil]].

	coreSample do:
		[:m |
			(m wantsDroppedMorph: aMorph event: evt) ifTrue: [^ m]].
	^ self world
