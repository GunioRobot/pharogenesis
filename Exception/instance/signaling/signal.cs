signal
	"Ask ContextHandlers in the sender chain to handle this signal.  The default is to execute and return my defaultAction."

	signalContext _ thisContext contextTag.
	^ thisContext nextHandlerContext handleSignal: self