globalsAsSet
	"Used by the inliner to avoid name clashes with global variables."

	((variablesSetCache == nil) or:
	 [variablesSetCache size ~= variables size]) ifTrue: [
		variablesSetCache _ variables asSet.
	].
	^ variablesSetCache