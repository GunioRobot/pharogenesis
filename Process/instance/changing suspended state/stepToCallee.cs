stepToCallee
	"Step until top context changes"

	| ctxt |
	ctxt _ suspendedContext.
	[ctxt == suspendedContext] whileTrue: [
		suspendedContext _ suspendedContext step].
	^ suspendedContext