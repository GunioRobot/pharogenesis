logError: errMsg inContext: aContext to: aFilename
	"Log the error message and a stack trace to the given file."
	| ff ctx |
	FileDirectory default deleteFileNamed: aFilename ifAbsent: [].
	(ff _ FileStream fileNamed: aFilename) ifNil: [^ self "avoid recursive errors"].
  	ff print: Date today; space; print: Time now; cr.
  	ff nextPutAll: errMsg; cr.
	"Note: The following is an open-coded version of ContextPart>>stackOfSize:
	since this method may be called during a low space condition and we might
	run out of space for allocating the full stack."
	ctx _ aContext.
	[ctx == nil] whileFalse:[
		ff print: ctx; cr.
		ctx _ ctx sender].
	ff close.