browseClassRefs

	| cls |
	cls := self selectedClass.
	(cls notNil and: [cls isTrait not])
		ifTrue: [self systemNavigation browseAllCallsOnClass: cls theNonMetaClass]
