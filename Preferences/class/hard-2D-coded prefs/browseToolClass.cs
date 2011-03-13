browseToolClass
	^ Preferences browserShowsPackagePane
		ifTrue:
			[PackagePaneBrowser]
		ifFalse:
			[Browser]