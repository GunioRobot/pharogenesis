controlTerminate

	| topController |
	super controlTerminate.
	topController := view topView controller.
	topController ifNotNil: [topController close].
