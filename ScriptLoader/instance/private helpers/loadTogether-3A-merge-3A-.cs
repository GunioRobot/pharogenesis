loadTogether: aCollection merge: aBoolean
	| loader |
	loader _ aBoolean
		ifTrue: [ MCVersionMerger new ]
		ifFalse: [ MCVersionLoader new].
	(self newerVersionsIn: aCollection)
		do: [:fn | loader addVersion: (self repository loadVersionFromFileNamed: fn)]
  	  	displayingProgress: 'Adding versions...'.
	aBoolean
		ifTrue: [[loader merge] on: MCMergeResolutionRequest do: [:request |
					request merger conflicts isEmpty
						ifTrue: [request resume: true]
						ifFalse: [request pass]]]
		ifFalse: [loader load]

