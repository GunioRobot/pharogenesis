cardForSqueakMap: aSqueakMap
	"Answer the current card or a new card."

	(aSqueakMap cardWithId: self squeakMapPackageID)
		ifNotNilDo: [ :card |
			(card installedVersion = self squeakMapPackageVersion) ifTrue: [ ^card ]
		].

	^self newCardForSqueakMap: aSqueakMap
