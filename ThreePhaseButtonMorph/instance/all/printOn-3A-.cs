printOn: aStream

	| string |

	aStream nextPutAll: '3PButton'.
	arguments size > 0 ifTrue: [string _ arguments at: (2 min: arguments size)].
	aStream nextPutAll: '('.
	(string ~~ nil and: [string ~~ self]) ifTrue:
			[aStream print: string; space]. 
	aStream print: self identityHash;
			nextPutAll: ')'.