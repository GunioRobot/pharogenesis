contextEnsure: block
	"Create an #ensure: context that is ready to return from executing its receiver"

	| ctxt chain |
	ctxt _ thisContext.
	[chain _ thisContext sender cut: ctxt. ctxt jump] ensure: block.
	"jump above will resume here without unwinding chain"
	^ chain