add: aClass toList: startUpOrShutDownList after: predecessor
	"Add the name of aClass to the startUp or shutDown list.
	Add it after the name of predecessor, or at the end if predecessor is nil."

	| name earlierName |
	name _ aClass name.
	(self at: name ifAbsent: [nil]) == aClass ifFalse:
		[self error: name , ' cannot be found in Smalltalk dictionary.'].
	predecessor == nil
		ifTrue: ["No-op if alredy in the list."
				(startUpOrShutDownList includes: name) ifFalse:
					[startUpOrShutDownList == StartUpList
						ifTrue: ["Add to end of startUp list"
								startUpOrShutDownList addLast: name]
						ifFalse: ["Add to front of shutDown list"
								startUpOrShutDownList addFirst: name]]]
		ifFalse: ["Add after predecessor, moving it if already there."
				earlierName _ predecessor name.
				(self at: earlierName) == predecessor ifFalse:
					[self error: earlierName , ' cannot be found in Smalltalk dictionary.'].
				(startUpOrShutDownList includes: earlierName) ifFalse:
					[self error: earlierName , ' cannot be found in the list.'].
				startUpOrShutDownList remove: name ifAbsent:[].
				startUpOrShutDownList add: name after: earlierName]