reportContexts

	| cntxt big small |
	big _ 0.
	cntxt _ freeLargeContexts.
	[cntxt = NilContext] whileFalse: [
		big _ big + 1.
		cntxt _ self fetchWord: 0 ofObject: cntxt.
	].
	small _ 0.
	cntxt _ freeSmallContexts.
	[cntxt = NilContext] whileFalse: [
		small _ small + 1.
		cntxt _ self fetchWord: 0 ofObject: cntxt.
	].
	self print: 'Recycled contexts: '.
	self printNum: small; print: ' small, '.
	self printNum: big; print: ' large ('.
	self printNum: (big * LargeContextSize) + (small * SmallContextSize).
	self print: ' bytes)'.
	self cr.