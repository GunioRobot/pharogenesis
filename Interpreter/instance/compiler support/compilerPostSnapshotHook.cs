compilerPostSnapshotHook
	self inline: true.
	compilerInitialized ifTrue: [self compilerPostSnapshot]