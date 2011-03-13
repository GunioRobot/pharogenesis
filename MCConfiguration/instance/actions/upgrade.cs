upgrade
	^Preferences upgradeIsMerge
		ifTrue: [self upgradeByMerging]
		ifFalse: [self upgradeByLoading]