browseToolClass
	^ Preferences browserShowsPackagePane
		ifTrue:
			[PackageBrowser]
		ifFalse:
			[Browser]