updatePartsViewer: aPartsViewer
	| aPlayer aPosition aNewPartsViewer oldOwner wasSticky |
	aPlayer _ aPartsViewer scriptedPlayer.
	aPosition _ aPartsViewer position.
	self removeFromViewerCache: aPlayer.
	wasSticky _ aPartsViewer isSticky.
	aNewPartsViewer _ PartsViewer new.
	wasSticky ifTrue: [aNewPartsViewer beSticky].
	oldOwner _ aPartsViewer owner.
	aPartsViewer delete.
	oldOwner ifNotNil: [oldOwner addMorph: aNewPartsViewer].
	aNewPartsViewer obtainBankInfoFrom: aPartsViewer.
	aNewPartsViewer setPlayer: aPlayer.
	aNewPartsViewer position: aPosition.
	self coloredTilesEnabled ifFalse:
		[aNewPartsViewer makeAllTilesGreen].
	self cacheViewer: aNewPartsViewer forPlayer: aPlayer