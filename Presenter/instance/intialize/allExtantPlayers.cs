allExtantPlayers
	"The initial intent here was to produce a list of Player objects associated with any Morph in the tree beneath the receiver's associatedMorph.  whether it is the submorph tree or perhaps off on unseen bookPages.  We have for the moment moved away from that initial intent, and in the current version we only deliver up players associated with the submorph tree only.  <-- this note dates from 4/21/99

Call #flushPlayerListCache; to force recomputation."

	| fullList objectsReferredToByTiles |
	playerList ifNotNil:
		[^ playerList].

	fullList _ associatedMorph allMorphs select: 
		[:m | m player ~~ nil] thenCollect: [:m | m player].
	fullList copy do:
		[:aPlayer |
			aPlayer class scripts do:
				[:aScript |  aScript isTextuallyCoded ifFalse:
					[aScript currentScriptEditor ifNotNilDo: [:ed |
						objectsReferredToByTiles _ ed allMorphs
							select:
								[:aMorph | (aMorph isKindOf: TileMorph) and: [aMorph type == #objRef]]
							thenCollect:
								[:aMorph | aMorph actualObject].
						fullList addAll: objectsReferredToByTiles]]]].

	^ playerList _ (fullList asSet asSortedCollection:
			[:a :b | a externalName < b externalName]) asArray