printOn: aStream

	| string |

	aStream nextPutAll: '3PButton'.
	arguments size > 0 ifTrue: [string _ arguments at: (2 min: arguments size)].
	aStream nextPutAll: '('.
	(string ~~ nil and: [string ~~ self])
		ifTrue:
			[aStream print: string; space]
		ifFalse:
			[aStream print: actionSelector; space].
	aStream print: self identityHash;
			nextPutAll: ')'.