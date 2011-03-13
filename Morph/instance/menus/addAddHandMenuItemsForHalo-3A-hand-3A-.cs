addAddHandMenuItemsForHalo: aMenu hand: aHandMorph
	"Add halo menu items to be handled by the invoking hand. The halo menu is invoked by clicking on the menu-handle of the receiver's halo."

	| unlockables aPlayer |
	aMenu addLine.
	self maybeAddCollapseItemTo: aMenu.

	aMenu add: 'copy to paste buffer' action: #copyToPasteBuffer:.
	aMenu addLine.
	aMenu add: 'copy Postscript' action: #clipPostscript.
	aMenu add: 'print PS to file...' target: self selector: #printPSToFile.

	(aPlayer _ self topRendererOrSelf player) ifNotNil:
		[aMenu addLine.
		aMenu add: 'make a sibling instance' target: self action: #makeNewPlayerInstance:.
		aMenu balloonTextForLastItem: 'Makes another morph whose player is of the same class as this one.  Both siblings will share the same scripts'.

		aMenu add: 'make multiple siblings...' target: self action: #makeMultipleSiblings:.
		aMenu balloonTextForLastItem: 'Make any number of sibling instances all at once'.

		(aPlayer belongsToUniClass and: [aPlayer class instanceCount > 1]) ifTrue:
			[aMenu add: 'make all siblings look like me' target: self action: #makeSiblingsLookLikeMe:.
			aMenu balloonTextForLastItem: 'make all my sibling instances look like me.'.

			aMenu add: 'bring all siblings to my location' target: self action: #bringAllSiblingsToMe:.
			aMenu balloonTextForLastItem: 'find all sibling instances and bring them to me'.

			aMenu add: 'apply status to all siblngs' target: self action: #applyStatusToAllSiblings:.
			aMenu balloonTextForLastItem: 'apply the current status of all of my scripts to the scripts of all my siblings']].
	aMenu addLine.

	self addFillStyleMenuItems: aMenu hand: aHandMorph.
	self addDropShadowMenuItems: aMenu hand: aHandMorph.
	self addLayoutMenuItems: aMenu hand: aHandMorph.
	aMenu addUpdating: #hasClipSubmorphsString target: self selector: #changeClipSubmorphs argumentList: #().
	aMenu addLine.
	self potentialEmbeddingTargets size > 1 ifTrue:
		[aMenu add: 'embed...' target: self action: #embedInto:].

	aMenu defaultTarget: self.
	aMenu addUpdating: #lockedString action: #lockUnlockMorph.
	unlockables _ self submorphs select:
		[:m | m isLocked].
	unlockables size == 1 ifTrue:
		[aMenu add: 'unlock "', unlockables first externalName, '"' action: #unlockContents].
	unlockables size > 1 ifTrue:
		[aMenu add: 'unlock all contents' action: #unlockContents.
		aMenu add: 'unlock...' action: #unlockOneSubpart].

	aMenu
		defaultTarget: self;
		add: 'add mouse up action' action: #addMouseUpAction;
		add: 'remove mouse up action' action: #removeMouseUpAction.

	aMenu addLine.

	(owner notNil and: [owner isStackBackground]) ifTrue:
		[self isShared
			ifFalse:
				[aMenu add: 'put onto Background' target: self action: #putOnBackground]
			ifTrue:
				[aMenu add: 'remove from Background' target: self action: #putOnForeground.
				self couldHoldSeparateDataForEachInstance ifTrue:
					[self holdsSeparateDataForEachInstance
						ifFalse:
							[aMenu add: 'start holding separate data for each instance' target: self action: #makeHoldSeparateDataForEachInstance]
						ifTrue:
							[aMenu add: 'stop holding separate data for each instance' target: self action: #stopHoldingSeparateDataForEachInstance].
							aMenu add: 'be default value on new card' target: self action: #setAsDefaultValueForNewCard.
							(self hasProperty: #thumbnailImage)
								ifTrue:
									[aMenu add: 'stop using for reference thumbnail' target: self action: #stopUsingForReferenceThumbnail]
								ifFalse:
									[aMenu add: 'start using for reference thumbnail' target: self action: #startUsingForReferenceThumbnail]]].
				aMenu addLine].

	aMenu defaultTarget: self topRendererOrSelf.
	aMenu add: 'draw new path' action: #definePath.
	(self hasProperty: #pathPoints) ifTrue:
		[aMenu add: 'follow path' action: #followPath.
		aMenu add: 'delete path' action: #deletePath].

	(owner == nil) ifFalse:
		[aMenu add: 'send to back' action: #goBehind.
		aMenu add: 'bring to front' action: #comeToFront].

	aMenu defaultTarget: aHandMorph.
