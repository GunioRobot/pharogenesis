release
	world == nil ifFalse:
		[world release.
		world _ nil].
	^ super release