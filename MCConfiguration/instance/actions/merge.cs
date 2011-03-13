merge
	^self depsSatisfying: [:dep | dep isFulfilledByAncestors not]
		versionDo: [:ver | ver merge]
		displayingProgress: 'merging packages'
