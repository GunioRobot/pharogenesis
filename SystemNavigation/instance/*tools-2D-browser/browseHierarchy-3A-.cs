browseHierarchy: aBehavior
	| targetClass |
	self hierarchyBrowserClass ifNil: [self error: 'No hierarchy browser installed:'].
	targetClass := aBehavior isMeta
				ifTrue: [aBehavior theNonMetaClass]
				ifFalse: [aBehavior ].
	self hierarchyBrowserClass newFor: targetClass