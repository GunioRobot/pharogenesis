renameTo: aName
	| aPresenter putInViewer aPasteUp renderer |
	(renderer _ self topRendererOrSelf) setNameTo: aName.
	(aPresenter _ self presenter) ifNotNil:
		[putInViewer _ aPresenter currentlyViewing: renderer player.
		putInViewer ifTrue: [aPresenter viewMorph: self]].
	(aPasteUp _ self topPasteUp) ifNotNil:
		[aPasteUp allTileScriptingElements do:
			[:m | m bringUpToDate]]