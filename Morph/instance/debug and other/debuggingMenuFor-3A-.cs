debuggingMenuFor: aHandMorph
	| aMenu aPlayer |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addStayUpItem.
	(self hasProperty: #errorOnDraw) ifTrue:
		[aMenu add: 'start drawing again' action: #resumeAfterDrawError.
		aMenu addLine].
	(self hasProperty: #errorOnStep) ifTrue:
		[aMenu add: 'start stepping again' action: #resumeAfterStepError.
		aMenu addLine].

	aMenu add: 'inspect morph' action: #inspectInMorphic.
	aMenu add: 'inspect owner chain' action: #inspectOwnerChain.
	Smalltalk isMorphic ifFalse:
		[aMenu add: 'inspect morph (in MVC)' action: #inspect].

     aMenu add: 'explore morph' target: self selector: #explore.
	(aPlayer _ self player) ifNotNil:
		[aMenu add: 'inspect player' target: aPlayer action: #inspect.
		Smalltalk isMorphic ifFalse: [aMenu add: 'inspect player (morphic)' action: #inspectArgumentsPlayerInMorphic]].

	aMenu addLine.
	aMenu add: 'browse morph class' target: self selector: #browseHierarchy.
	aPlayer ifNotNil: 
		[aMenu add: 'browse player class' target: aPlayer action: #inspect].
	aMenu addLine.
	aMenu add: 'make own subclass' target: aHandMorph action: #subclassMorph.
	aMenu add: 'internal name ' action: #choosePartName.
	aMenu add: 'save morph in file'  action: #saveOnFile.
	aMenu addLine.
	aMenu add: 'call #tempCommand' target: aHandMorph action: #callTempCommand.
	aMenu add: 'define #tempCommand' target: aHandMorph action: #defineTempCommand.

	aMenu addLine.
	aMenu add: 'control-menu...' target: aHandMorph selector: #invokeMetaMenuFor: argument: self.
	aMenu add: 'edit balloon help' action: #editBalloonHelpText.
	^ aMenu