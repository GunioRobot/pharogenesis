packagePanePreferenceChanged
	| theOtherOne |
	self registeredClasses size = 2
		ifTrue: [theOtherOne _ (self registeredClasses copyWithout: PackagePaneBrowser) first]
		ifFalse: [theOtherOne _ nil].
	(Preferences valueOfFlag: #browserShowsPackagePane ifAbsent: [false])
		ifTrue: [self default: PackagePaneBrowser]
		ifFalse: [self default: theOtherOne].
