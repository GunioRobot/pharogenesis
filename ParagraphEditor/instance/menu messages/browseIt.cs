browseIt
	"Launch a browser for the current selection, if appropriate.  2/96 sw.
	In this initial version, we open a system browser on a class, and an implementors browser on a selector, otherwise we flash.
	2/29/96 sw: select current line first, if selection was an insertion pt"

	| aSymbol anEntry |
	self selectLine.

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
				[Smalltalk implementorsOf: aSymbol]]