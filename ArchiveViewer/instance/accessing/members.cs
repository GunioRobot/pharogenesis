members
	^archive ifNil: [ #() asOrderedCollection ]
		ifNotNil: [ archive members asOrderedCollection ]