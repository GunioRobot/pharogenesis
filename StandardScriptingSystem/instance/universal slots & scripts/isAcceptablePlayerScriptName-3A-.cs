isAcceptablePlayerScriptName: aSymbol
	(StandardSlotInfo includesKey: aSymbol) ifTrue: [^ false].
	(StandardScriptInfo includesKey: aSymbol) ifTrue: [^ false].
	self flag: #deferred.   "Flesh out the list below and put it into a class variable"
	(#(costume costumes dependents true false size) includes: aSymbol) ifTrue: [^ false].
	(Player basicNew respondsTo: aSymbol) ifTrue:
		[^ false].
	^ true