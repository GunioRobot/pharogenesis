stackDepth
	| ctxt n |
	ctxt _ activeContext.
	n _ 0.
	[(ctxt _ (self fetchPointer: SenderIndex ofObject: ctxt)) = nilObj]
		whileFalse: [n _ n+1].
	^ n