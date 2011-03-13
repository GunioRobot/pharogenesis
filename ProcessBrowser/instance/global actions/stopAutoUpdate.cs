stopAutoUpdate
	self isAutoUpdating
		ifTrue: [autoUpdateProcess terminate.
			autoUpdateProcess _ nil].
	self updateProcessList