browseClassRefs

	| cls |
	(cls _ self selectedClass) ifNotNil: [
		self systemNavigation browseAllCallsOnClass: cls theNonMetaClass]
