browseIt
	"Launch a browser for the current selection, if appropriate"

	| aSymbol anEntry |
	self flag: #yoCharCases.

	Preferences alternativeBrowseIt ifTrue: [^ self browseClassFromIt].

	self lineSelectAndEmptyCheck: [^ self].
	(aSymbol _ self selectedSymbol) isNil ifTrue: [^ view flash].

	self terminateAndInitializeAround:
		[aSymbol first isUppercase
			ifTrue:
				[anEntry _ (Smalltalk
					at: aSymbol
					ifAbsent:
						[ self systemNavigation browseAllImplementorsOf: aSymbol.
						^ nil]).
				anEntry isNil ifTrue: [^ view flash].
				(anEntry isBehavior or: [ anEntry isTrait ])
					ifFalse: [ anEntry := anEntry class ].
				ToolSet browse: anEntry selector: nil.
		] ifFalse:[ self systemNavigation browseAllImplementorsOf: aSymbol]]