addPlayerItemsTo: aMenu
	"Add player-related items to the menu if appropriate"

	| aPlayer subMenu |
	aPlayer _ self topRendererOrSelf player.
	subMenu _ MenuMorph new defaultTarget: self.
	subMenu add: 'make a sibling instance' translated target: self action: #makeNewPlayerInstance:.
	subMenu balloonTextForLastItem: 'Makes another morph whose player is of the same class as this one.  Both siblings will share the same scripts' translated.

	subMenu add: 'make multiple siblings...' translated target: self action: #makeMultipleSiblings:.
	subMenu balloonTextForLastItem: 'Make any number of sibling instances all at once' translated.

	(aPlayer belongsToUniClass and: [aPlayer class instanceCount > 1]) ifTrue:
		[subMenu addLine.
		subMenu add: 'make all siblings look like me' translated target: self action: #makeSiblingsLookLikeMe:.
		subMenu balloonTextForLastItem: 'make all my sibling instances look like me.' translated.

		subMenu add: 'bring all siblings to my location' translated target: self action: #bringAllSiblingsToMe:.
		subMenu balloonTextForLastItem: 'find all sibling instances and bring them to me' translated.

		subMenu add: 'apply status to all siblngs' translated target: self action: #applyStatusToAllSiblings:.
		subMenu balloonTextForLastItem: 'apply the current status of all of my scripts to the scripts of all my siblings' translated].

		subMenu add: 'indicate all siblings' translated target: self action: #indicateAllSiblings.
		subMenu balloonTextForLastItem: 'momentarily show, by flashing , all of my visible siblings.'.

		aMenu add: 'siblings...' translated subMenu: subMenu

