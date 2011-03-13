renameTo: aName
	"Set Player name in costume.  Update Viewers.  Fix all tiles (old style).  fix References.  New tiles: recompile, and recreate open scripts.  If coming in from disk, and have name conflict, References will already have new name."
	| aPresenter putInViewer aPasteUp renderer oldKey assoc classes oldName ut |
	oldName _ self knownName.
	(renderer _ self topRendererOrSelf) setNameTo: aName.
	putInViewer _ false.
	((aPresenter _ self presenter) isNil or: [renderer player isNil]) ifFalse:
		[putInViewer _ aPresenter currentlyViewing: renderer player.
		putInViewer ifTrue:
			[renderer player viewerFlapTab hibernate]].  "empty it temporarily"
	(aPasteUp _ self topPasteUp) ifNotNil:
		[aPasteUp allTileScriptingElements do: [:m | m bringUpToDate]].

	"Fix References dictionary.  See restoreReferences to know why oldKey is 
		already aName, but oldName is the old name."
	oldKey _ References keyAtIdentityValue: renderer player ifAbsent: [nil].
	oldKey ifNotNil:
		[assoc _ References associationAt: oldKey.
		oldKey = aName ifFalse: ["normal rename"
			assoc key: aName asSymbol.
			References rehash]].

	putInViewer ifTrue: [aPresenter viewMorph: self].	"recreate my viewer"
	oldKey ifNil: [^ aName].

	"Force strings in tiles to be remade with new name.  New tiles only."
	ut _ aPasteUp 
		ifNil: [self player isUniversalTiles]
		ifNotNil: [aPasteUp valueOfProperty: #universalTiles ifAbsent: [false]].
	ut ifFalse: [^ aName].
	classes _ (Smalltalk allCallsOn: assoc) collect: [:classAndMethod | 
		(classAndMethod findTokens: Character separators) first asSymbol].
	(classes asSet) do: [:clsName |
		(Smalltalk at: clsName) replaceSilently: oldName to: aName].
		"replace in text body of all methods.  Can be wrong!"
	"Redo the tiles that are showing.  This is also done in caller in unhibernate."
	aPasteUp ifNotNil: [
		aPasteUp allTileScriptingElements do: [:mm | "just ScriptEditorMorphs".
			(mm isKindOf: ScriptEditorMorph) ifTrue:
				[((mm playerScripted class compiledMethodAt: mm scriptName) hasLiteral: assoc)
					ifTrue: [mm hibernate; unhibernate]]]].
	^ aName