serversInGroup
	^self groupName
		ifNil: [Array with: self]
		ifNotNil: [self class serversInGroupNamed: self groupName]