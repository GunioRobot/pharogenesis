stepToCallee
	"Step to callee or sender"

	| ctxt |
	ctxt _ self.
	[(ctxt _ ctxt step) == self] whileTrue.
	^ ctxt