reloadVersionInfos
	workingCopy ifNil: [^ versionInfo _ nil].
	
	self versionCache rescan.
	versionInfo _ self versionInfos
					detect: [:ea | workingCopy ancestors includes: ea]
					ifNone: [].