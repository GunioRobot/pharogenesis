setCompilerInitialized: newFlag
	| oldFlag |
	oldFlag _ compilerInitialized.
	compilerInitialized _ newFlag.
	^oldFlag