addTree: aFileNameOrDirectory removingFirstCharacters: n match: aBlock
	| dir newMember fullPath relativePath |
	dir := (aFileNameOrDirectory isString)
		ifTrue: [ FileDirectory on: aFileNameOrDirectory ]
		ifFalse: [ aFileNameOrDirectory ].
	fullPath := dir pathName, dir slash.
	relativePath := fullPath copyFrom: n + 1 to: fullPath size.
	(dir entries select: [ :entry | aBlock value: entry])
		do: [ :ea | | fullName |
		fullName := fullPath, ea name.
		newMember := ea isDirectory
				ifTrue: [ self memberClass newFromDirectory: fullName ]
				ifFalse: [ self memberClass newFromFile: fullName ].
		newMember localFileName: relativePath, ea name.
		self addMember: newMember.
		ea isDirectory ifTrue: [ self addTree: fullName removingFirstCharacters: n match: aBlock].
	].
