addRequiredDirtyPackage
	| dirtyPackages |
	dirtyPackages := self workingCopies select: [:copy | copy needsSaving].

	workingCopy ifNotNil:
		[:wc |
		dirtyPackages do:
			[:required |
			wc requirePackage: required package]].
	
	self workingCopyListChanged