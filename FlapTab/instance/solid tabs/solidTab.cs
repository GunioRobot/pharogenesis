solidTab
	self isCurrentlySolid
		ifFalse:
			[self useSolidTab]
		ifTrue:
			[self changeTabSolidity]