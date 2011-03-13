release
	projectWindows == nil ifFalse:
		[projectWindows release.
		projectWindows _ nil].
	^ super release