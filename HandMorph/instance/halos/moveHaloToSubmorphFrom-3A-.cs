moveHaloToSubmorphFrom: anObject
	| morphList reply |
	morphList _ anObject submorphs.
	morphList size == 1
		ifTrue:
			[reply _ morphList first]
		ifFalse:
			[reply _ (SelectionMenu labelList: (morphList collect: [:m | m externalName]) selections: morphList) startUp.
			reply ifNil: [^ self]].
	
	self setArgument: reply.
	self addHalo