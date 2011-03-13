packagePanePreferenceChanged
	| theOtherOne |
	self registeredClasses size = 2
		ifTrue: [theOtherOne := (self registeredClasses copyWithout: PackagePaneBrowser) first]
		ifFalse: [theOtherOne := nil].
	(Preferences valueOfFlag: #browserShowsPackagePane ifAbsent: [false])
		ifTrue: [self default: PackagePaneBrowser]
		ifFalse: [self default: theOtherOne].
	SystemNavigation default browserClass: self default.