addAttributesToText: aText forParent: aVersionInfo
	(versionInfo hasAncestor: aVersionInfo) ifTrue: [aText addAttribute: self relativeAttribute from: 1 to: aText size].
	(versionInfo ancestors includes: aVersionInfo) ifTrue: [aText addAttribute: self closeRelativeAttribute from: 1 to: aText size].