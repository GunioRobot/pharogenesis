renameTo: aName
	| aPresenter putInViewer oldKey assoc |
	self setName: aName.
	putInViewer _ false.
	((aPresenter _ self presenter) isNil) ifFalse:
		[putInViewer _ aPresenter currentlyViewing: self.
		putInViewer ifTrue:
			[self viewerFlapTab hibernate]].  "empty it temporarily"

	"Fix References dictionary.  See restoreReferences to know why oldKey is 
		already aName, but oldName is the old name."
	oldKey _ References keyAtIdentityValue: self ifAbsent: [nil].
	oldKey ifNotNil:
		[assoc _ References associationAt: oldKey.
		oldKey = aName ifFalse: ["normal rename"
			assoc key: aName asSymbol.
			References rehash]].

	World allTileScriptingElements do: [:m | m bringUpToDate].

	putInViewer ifTrue: [aPresenter viewObject: self].	"recreate my viewer"
	oldKey ifNil: [^ aName].
	^ aName