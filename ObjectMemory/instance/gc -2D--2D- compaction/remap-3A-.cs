remap: oop
	"Map the given oop to its new value during a compaction or become: operation. If it has no forwarding table entry, return the oop itself."

	| fwdBlock |
	self inline: false.
	(self isObjectForwarded: oop) ifTrue: [
		"get the new value for oop from its forwarding block"
		fwdBlock _ ((self longAt: oop) bitAnd: AllButMarkBitAndTypeMask) << 1.
		DoAssertionChecks ifTrue: [ self fwdBlockValidate: fwdBlock ].
		^ self longAt: fwdBlock
	].
	^ oop