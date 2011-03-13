openExplorerFor: anObject
"
ObjectExplorer new openExplorerFor: Smalltalk
"

	| win |
	win := (self explorerFor: anObject) openInWorld.
	Cursor wait showWhile:
		[win submorphs do:
			[:sm|
			(sm respondsTo: #expandRoots) ifTrue:
				[sm expandRoots]]].
	^self
