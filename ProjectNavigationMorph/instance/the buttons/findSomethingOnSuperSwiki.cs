findSomethingOnSuperSwiki

	| projectServers server index |
	projectServers := ServerDirectory projectServers.
	projectServers isEmpty
		ifTrue: [^self].
	projectServers size = 1
		ifTrue: [server := projectServers first]
		ifFalse: [index := (PopUpMenu labelArray: (projectServers collect: [:each | (ServerDirectory nameForServer: each) translatedIfCorresponds]) lines: #()) 
				startUpWithCaption: 'Choose a super swiki:' translated.
			index > 0
				ifTrue: [server := projectServers at: index]
				ifFalse: [^self]].
	EToyProjectQueryMorph onServer: server