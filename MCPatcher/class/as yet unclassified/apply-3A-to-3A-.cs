apply: aPatch to: aSnapshot
	| loader |
	loader _ self snapshot: aSnapshot.
	aPatch applyTo: loader.
	^ loader patchedSnapshot