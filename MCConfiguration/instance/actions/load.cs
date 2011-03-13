load
	^self depsSatisfying: [:dep | dep isCurrent not]
		versionDo: [:ver | ver load]
		displayingProgress: 'loading packages'
