browseClass: aBehavior
	| targetClass |
	self browserClass ifNil: [self error: 'No browser installed:'].
	targetClass := aBehavior isMeta
				ifTrue: [aBehavior theNonMetaClass]
				ifFalse: [aBehavior ].
	self browserClass newOnClass: targetClass