textForVersionInfo: aVersionInfo
	| text |
	text _ aVersionInfo name asText.
	versionInfo ifNotNil:
		[(workingCopy ancestors includes: aVersionInfo)
			ifTrue: [text addAttribute: self loadedAttribute from: 1 to: text size].
		versionInfo = aVersionInfo ifFalse:
			[(versionInfo isRelatedTo: aVersionInfo) ifTrue: [text addAttribute: self relativeAttribute from: 1 to: text size]]].
	^ text