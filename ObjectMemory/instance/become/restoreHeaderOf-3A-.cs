restoreHeaderOf: oop
	"Restore the original header of the given oop from its forwarding block."

	| fwdHeader fwdBlock |
	fwdHeader _ self longAt: oop.
	fwdBlock _ (fwdHeader bitAnd: AllButMarkBitAndTypeMask) << 1.

	DoAssertionChecks ifTrue: [
		(fwdHeader bitAnd: MarkBit) = 0 ifTrue: [
			self error: 'attempting to restore the header of an object that has no forwarding block'.
		].
		self fwdBlockValidate: fwdBlock.
	].

	self longAt: oop put: (self longAt: fwdBlock + 4).  "restore orginal header"