browseIt
	"Launch a browser for the current selection, if appropriate"

	| aSymbol anEntry brow |

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
				(anEntry isKindOf: Class)
					ifFalse:	[anEntry _ anEntry class].
				brow _ SystemBrowser default new.
				brow setClass: anEntry selector: nil.
				brow class
					openBrowserView: (brow openEditString: nil)
					label: 'System Browser']
			ifFalse:
				[ self systemNavigation browseAllImplementorsOf: aSymbol]]