topEditor
	"Return the top-most editor around the receiver"

	| found tested |
	tested := self.
	[tested isNil] whileFalse: 
			[tested isTileEditor ifTrue: [found := tested].
			tested := tested owner].
	^found