dropTargetFor: aMorph event: evt
	"Return the morph that the given morph is to be dropped onto. Return the world, if no other morph wants the dropping morph."

	| root |
	"find front-most composite morph"
	root _ nil.
	owner submorphsReverseDo: [:m |
		((m fullContainsPoint: evt cursorPoint) and:
		 [(m isKindOf: HaloMorph) not]) ifTrue: [root _ m]].
	root == nil ifTrue: [^ self world].
	(root unlockedMorphsAt: evt cursorPoint) do: [:m |
		(m wantsDroppedMorph: aMorph event: evt) ifTrue: [^ m]].
	^ self world
