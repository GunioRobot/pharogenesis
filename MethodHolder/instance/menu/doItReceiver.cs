doItReceiver
	"If there is an instance associated with me, answer it, for true mapping of self.  If not, then do what other code-bearing tools do, viz. give access to the class vars."

	(self dependents detect: [:m | m isKindOf: MethodMorph]) ifNotNilDo:
		[:mm | (mm owner isKindOf: ScriptEditorMorph) ifTrue:
			[^ mm owner playerScripted]].

	^ self selectedClass ifNil: [FakeClassPool new]