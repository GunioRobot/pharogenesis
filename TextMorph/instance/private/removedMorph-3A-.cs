removedMorph: aMorph
	| range |
	range _ text find: (TextAnchor new anchoredMorph: aMorph).
	range ifNotNil:
		[self paragraph replaceFrom: range first to: range last
				with: Text new displaying: false.
		self fit].
	aMorph textAnchorType: nil.
	aMorph relativeTextAnchorPosition: nil.
	super removedMorph: aMorph.