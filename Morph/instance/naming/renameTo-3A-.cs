renameTo: aName
	| aPresenter putInViewer |
	self setNameTo: aName.
	(aPresenter _ self world presenter) ifNotNil:
		[putInViewer _ aPresenter currentlyViewing: costumee.
		aPresenter flushViewerCache.
		putInViewer ifTrue: [aPresenter viewMorph: self]].
	self world allTileScriptingElements do:
		[:m | m bringUpToDate]