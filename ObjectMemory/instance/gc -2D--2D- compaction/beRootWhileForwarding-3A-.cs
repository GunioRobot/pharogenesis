beRootWhileForwarding: oop
	"Record that the given oop in the old object area points to an object in the young area when oop may be forwarded. Like beRoot:"
	"Warning: No young objects should be recorded as roots. Callers are responsible for ensuring this constraint is not violated."

	| header forwarding fwdBlock newHeader |
	header _ self longAt: oop.
	(header bitAnd: MarkBit) ~= 0 ifTrue: [
		forwarding _ true.
		fwdBlock _ header bitAnd: AllButMarkBitAndTypeMask.
		checkAssertions ifTrue: [ self fwdBlockValidate: fwdBlock ].
		header _ self longAt: fwdBlock + 4.
	] ifFalse: [
		forwarding _ false.
	].

	(header bitAnd: RootBit) = 0 ifTrue: [
		"record oop as root only if not already recorded"
		rootTableCount < RootTableSize ifTrue: [
			"record root only if there is room in the roots table"
			rootTableCount _ rootTableCount + 1.
			rootTable at: rootTableCount put: oop.
			newHeader _ header bitOr: RootBit.
			forwarding
				ifTrue: [ self longAt: (fwdBlock + 4) put: newHeader ]
				ifFalse: [ self longAt: oop put: newHeader ].
		].
	].