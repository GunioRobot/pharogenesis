addAddHandMenuItemsForHalo: aMenu hand: aHandMorph
	"Add halo menu items to be handled by the invoking hand. The halo menu is invoked by clicking on the menu-handle of the receiver's halo."

	| unlockables |
	aMenu addLine.
	self maybeAddCollapseItemTo: aMenu.

	aMenu add: 'copy to paste buffer' action: #copyToPasteBuffer.
	aMenu add: 'copy Postscript' action: #clipPostscript.
	aMenu add: 'print PS to file...' target: self selector: #printPSToFile.

	self player ifNotNil:
		[aMenu add: 'make another instance of me' action: #makeNewPlayerInstance].
	aMenu addLine.

	aMenu add: 'change costume...' action: #chooseNewCostumeForArgument.

	"Add the fill style items"
	self addFillStyleMenuItems: aMenu hand: aHandMorph.

	aHandMorph potentialEmbeddingTargets size > 1 ifTrue:
		[aMenu add: 'embed...' action: #placeArgumentIn].

	self isLocked
		ifFalse:
			[aMenu add: 'lock' action: #lockMorph]
		ifTrue:
			[aMenu add: 'unlock' action: #unlockMorph].  "probably not possible -- wouldn't get halo"
	unlockables _ self submorphs select:
		[:m | m isLocked].
	unlockables size == 1 ifTrue:
		[aMenu add: 'unlock "', unlockables first externalName, '"' action: #unlockContents].
	unlockables size > 1 ifTrue:
		[aMenu add: 'unlock all contents' action: #unlockContents.
		aMenu add: 'unlock...' action: #unlockOneSubpart].

	aMenu addLine.
	aMenu defaultTarget: self topRendererOrSelf.
	aMenu add: 'draw new path' action: #definePath.
	(self hasProperty: #pathPoints) ifTrue:
		[aMenu add: 'follow path' action: #followPath.
		aMenu add: 'delete path' action: #deletePath].

	(owner == nil) ifFalse:
		[aMenu add: 'send to back' action: #goBehind.
		aMenu add: 'bring to front' action: #comeToFront].

	aMenu defaultTarget: aHandMorph.
