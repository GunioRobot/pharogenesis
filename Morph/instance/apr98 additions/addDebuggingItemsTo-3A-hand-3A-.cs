addDebuggingItemsTo: aMenu hand: aHandMorph
	| subMenu |
	subMenu _ MenuMorph new defaultTarget: aHandMorph.

	subMenu add: 'control-menu...' target: aHandMorph selector: #invokeMetaMenuFor: argument: aHandMorph argument.
	subMenu add: 'inspect morph' action: #inspectArgument.
	World ifNil:
		[subMenu add: 'inspect morph (morphic)' action: #inspectArgumentInMorphic].
	subMenu add: 'browse morph class' action: #browseMorphClass.

	costumee ifNotNil:
		[subMenu add: 'inspect player' action: #inspectCostumee.
		World ifNil: [subMenu add: 'inspect player (morphic)' action: #inspectArgumentsCostumeeInMorphic].
		subMenu add: 'browse player class' action: #browsePlayerClass].


	subMenu add: 'make own subclass' action: #subclassMorph.
	subMenu add: 'internal name' action: #nameMorph.
	subMenu add: 'save morph in file' action: #saveMorphInFile.

	subMenu defaultTarget: self.
	subMenu add: 'edit balloon help' action: #editBalloonHelpText.
	subMenu add: 'temp command' action: #tempCommand.

	aMenu add: 'debug...' subMenu: subMenu