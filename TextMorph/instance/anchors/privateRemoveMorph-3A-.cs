privateRemoveMorph: aMorph
	| range |
	range _ text find: (TextAnchor new anchoredMorph: aMorph).
	range ifNotNil:
		[self paragraph replaceFrom: range first to: range last
				with: Text new displaying: false.
		self fit.
		aMorph position: 0@0.   "so fits in hand"].
	super privateRemoveMorph: aMorph