stepToHome: aContext 
	"Resume self until the home of top context is aContext.  Top context may be a block context."

	| home ctxt |
	home _ aContext home.
	[	ctxt _ self step.
		home == ctxt home.
	] whileFalse: [
		home isDead ifTrue: [^ self suspendedContext].
	].
	^ self suspendedContext