topView
	"Find the first top view on me. Is there any danger of their being two with the same model?  Any danger from ungarbage collected old views?  Ask if schedulled?"

	dependents ifNil: [^nil].
	Smalltalk isMorphic 
		ifTrue: 
			[dependents 
				do: [:v | ((v isSystemWindow) and: [v isInWorld]) ifTrue: [^v]].
			^nil].
	dependents do: [:v | v superView ifNil: [v model == self ifTrue: [^v]]].
	^nil