stopAutoUpdate
	autoUpdateProcess ifNotNil: [
		autoUpdateProcess terminate.
		autoUpdateProcess _ nil].
	self updateProcessList