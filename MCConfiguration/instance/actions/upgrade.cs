upgrade
	^self depsSatisfying: [:dep | dep isFulfilledByAncestors not]
		versionDo: [:ver | 
			(Preferences upgradeIsMerge and: [self mustMerge: ver])
				ifFalse: [ver load]
				ifTrue: [[ver merge]
					on: MCMergeResolutionRequest do: [:request |
						request merger conflicts isEmpty
							ifTrue: [request resume: true]
							ifFalse: [request pass]]]]
		displayingProgress: 'upgrading packages'
