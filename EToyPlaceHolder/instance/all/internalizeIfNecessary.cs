internalizeIfNecessary
	| doc aHolder |
	doc _ HTTPSocket httpGet: url accept: 'application/octet-stream'.
	doc class == String
		ifTrue:
			[^ self inform: 'Oops. Can''t find EToy ', url].
	doc reset.
	aHolder _ doc fileInObjectAndCode.
	aHolder ifNil: [self isThisEverCalled].

	aHolder initializeScaffoldingContentsForReloadedEToy.
	aHolder title: title.
	self become: aHolder