previousPc

	| currentPc dummy prevPc |
	currentPc _ pc.
	pc _ self method initialPC.
	dummy _ MessageCatcher new.
	[pc = currentPc] whileFalse: [
		prevPc _ pc.
		self interpretNextInstructionFor: dummy.
	].
	^ prevPc