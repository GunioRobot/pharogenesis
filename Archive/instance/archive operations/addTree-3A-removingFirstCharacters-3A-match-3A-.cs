addTree: aFileNameOrDirectory removingFirstCharacters: n match: aBlock
	| dir newMember fullPath relativePath |
	dir _ (aFileNameOrDirectory isString)
		ifTrue: [ FileDirectory on: aFileNameOrDirectory ]
		ifFalse: [ aFileNameOrDirectory ].
	fullPath _ dir pathName, dir slash.
	relativePath _ fullPath copyFrom: n + 1 to: fullPath size.
	(dir entries select: [ :entry | aBlock value: entry])
		do: [ :ea | | fullName |
		fullName _ fullPath, ea name.
		newMember _ ea isDirectory
				ifTrue: [ self memberClass newFromDirectory: fullName ]
				ifFalse: [ self memberClass newFromFile: fullName ].
		newMember localFileName: relativePath, ea name.
		self addMember: newMember.
		ea isDirectory ifTrue: [ self addTree: fullName removingFirstCharacters: n match: aBlock].
	].
