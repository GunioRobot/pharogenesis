contextOn: exceptionClass do: block
	"Create an #on:do: context that is ready to return from executing its receiver"

	| ctxt chain |
	ctxt _ thisContext.
	[chain _ thisContext sender cut: ctxt. ctxt jump] on: exceptionClass do: block.
	"jump above will resume here without unwinding chain"
	^ chain