controlTerminate

	| topController |
	super controlTerminate.
	topController _ view topView controller.
	topController ifNotNil: [topController close].
