browseIt
	"Launch a browser for the current selection, if appropriate"

	| aSymbol anEntry brow |
	self lineSelectAndEmptyCheck: [^ self].
	(aSymbol _ self selectedSymbol) isNil ifTrue: [^ view flash].

	self terminateAndInitializeAround:
		[aSymbol first isUppercase
			ifTrue:
				[anEntry _ (Smalltalk at: aSymbol ifAbsent: [nil]).
				anEntry isNil ifTrue: [^ view flash].
				(anEntry isKindOf: Class)
					ifTrue:
						[brow _ Browser new.
						brow setClass: anEntry selector: nil.
						Browser openBrowserView: (brow openEditString: nil)
							label: 'System Browser']
					ifFalse:
						[anEntry inspect]]
			ifFalse:
				[Smalltalk browseAllImplementorsOf: aSymbol]]