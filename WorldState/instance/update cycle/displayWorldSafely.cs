displayWorldSafely
	"Update this world's display and keep track of errors during draw methods."
	| oldHandler errCtx errMorph |
	oldHandler _ Processor activeProcess errorHandler.
	[self displayWorld] ifError:[:err :rcvr|
		"Handle a drawing error"
		errCtx _ thisContext.
		[errCtx _ errCtx sender.
		"Search the sender chain to find the morph causing the problem"
		[errCtx notNil and:[(errCtx receiver isKindOf: Morph) not]] 
			whileTrue:[errCtx _ errCtx sender].
		"If we're at the root of the context chain then we have a fatal drawing problem"
		errCtx == nil ifTrue:[^self handleFatalDrawingError: err].
		errMorph _ errCtx receiver.
		"If the morph causing the problem has already the #drawError flag set,
		then search for the next morph above in the caller chain."
		errMorph hasProperty: #errorOnDraw] whileTrue.
		errMorph setProperty: #errorOnDraw toValue: true.
		"Install the old error handler, so we can re-raise the error"
		Processor activeProcess errorHandler: oldHandler.
		rcvr error: err.
	].