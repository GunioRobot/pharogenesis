findContextSuchThat: testBlock
	"Search self and my sender chain for first one that satisfies testBlock.  Return nil if none satisfy"

	| ctxt |
	ctxt _ self.
	[ctxt isNil] whileFalse: [
		(testBlock value: ctxt) ifTrue: [^ ctxt].
		ctxt _ ctxt sender.
	].
	^ nil