addAttributesToText: aText forChild: aVersionInfo
	versionInfo ifNotNil:
		[(aVersionInfo hasAncestor: versionInfo) ifTrue: [aText addAttribute: self relativeAttribute from: 1 to: aText size].
		(aVersionInfo ancestors includes: versionInfo) ifTrue: [aText addAttribute: self closeRelativeAttribute from: 1 to: aText size]].