compilerPreSnapshotHook
	self inline: true.
	compilerInitialized ifTrue: [self compilerPreSnapshot]