rootForGrabOf: aMorph
	"Allow submorph to be extracted."

	| root |
true ifTrue: [^ super rootForGrabOf: aMorph].
	self inPartsBin ifTrue: [^ super rootForGrabOf: aMorph].

	root _ aMorph.
	[root = self] whileFalse:
		[root owner = self ifTrue:
			[root color: (ScriptingSystem colorForType: root resultType).
			^ root].
		root _ root owner].
	^ super rootForGrabOf: aMorph
