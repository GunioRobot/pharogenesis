enclosingEditor
	"Return the next editor around the receiver"

	| tested |
	tested := owner.
	[tested isNil] whileFalse: 
			[tested isTileEditor ifTrue: [^tested].
			tested := tested owner].
	^nil