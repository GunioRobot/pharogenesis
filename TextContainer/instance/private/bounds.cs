bounds
	| bounds |
	self fillsOwner ifTrue:
		[self avoidsOcclusions
			ifTrue: [bounds _ textMorph owner bounds.
					textMorph owner submorphsBehind: textMorph do:
						[:m | bounds _ bounds merge: m fullBounds]]
			ifFalse: [bounds _ textMorph owner fullBounds]]
		ifFalse:
		[bounds _ textMorph bounds].
	^ bounds