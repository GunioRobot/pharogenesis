addAddHandMenuItemsForHalo: aMenu hand: aHandMorph
	"Add halo menu items to be handled by the invoking hand. The halo menu is invoked by clicking on the menu-handle of the receiver's halo."

	| unlockables |
	aMenu addLine.
	aMenu add: 'copy to paste buffer' action: #copyToPasteBuffer.
	aMenu addLine.

	aMenu add: 'open viewer' action: #openViewerForArgument.
	aMenu add: 'change costume...' action: #chooseNewCostumeForArgument.
	((self isKindOf: SketchMorph) and: [GIFImports size > 0]) ifTrue:
		[aMenu add: 'use imported graphic...' action: #chooseNewFormForSketchMorph].

	"costumee ifNotNil:
		[aMenu add: 'make another instance of me' action: #makeNewPlayerInstance]."

	self colorSettable ifTrue:
		[aMenu add: 'change color...' action: #changeColor].

	(aHandMorph argument pasteUpMorph morphsAt: aHandMorph menuTargetOffset) size > 2 ifTrue:
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

	"aMenu add: 'make mouse-sensitive' action: #makeMouseSensitive."
	(owner == nil or: [self == owner submorphs last]) ifFalse:
		[aMenu add: 'send to back' action: #goBehind]