beRootWhileForwarding: oop
	"Record that the given oop in the old object area points to an object in the young area when oop may be forwarded."
	"Warning: No young objects should be recorded as roots. Callers are responsible for ensuring this constraint is not violated."

	| header fwdBlock |
	header _ self longAt: oop.
	(header bitAnd: MarkBit) ~= 0
		ifTrue: ["This oop is forwarded"
				fwdBlock _ (header bitAnd: AllButMarkBitAndTypeMask) << 1.
				DoAssertionChecks ifTrue: [ self fwdBlockValidate: fwdBlock ].
				self noteAsRoot: oop headerLoc: fwdBlock + 4]
		ifFalse: ["Normal -- no forwarding"
				self noteAsRoot: oop headerLoc: oop]