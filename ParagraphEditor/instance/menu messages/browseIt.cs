browseIt
	"Launch a browser for the current selection, if appropriate"

	| aSymbol anEntry |
	self lineSelectAndEmptyCheck: [^ self].
	(aSymbol _ self selectedSymbol) isNil ifTrue: [^ view flash].

	self terminateAndInitializeAround:
		[aSymbol first isUppercase
			ifTrue:
				[anEntry _ (Smalltalk at: aSymbol ifAbsent: [nil]).
				anEntry isNil ifTrue: [^ view flash].
				(anEntry isKindOf: Class)
					ifTrue:
						[BrowserView browseFullForClass: anEntry method: nil from: self]
					ifFalse:
						[anEntry inspect]]
			ifFalse:
				[Smalltalk browseAllImplementorsOf: aSymbol]]