addAttributesToText: aText for: aVersionInfo
	(workingCopy ancestors includes: aVersionInfo)
		ifTrue: [aText addAttribute: self loadedAttribute from: 1 to: aText size]