buildDebugMenu: aHand
	"Answer a debugging menu for the receiver.  The hand argument is seemingly historical and plays no role presently"

	| aMenu aPlayer |

	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addStayUpItem.
	(self hasProperty: #errorOnDraw) ifTrue:
		[aMenu add: 'start drawing again' action: #resumeAfterDrawError.
		aMenu addLine].
	(self hasProperty: #errorOnStep) ifTrue:
		[aMenu add: 'start stepping again' action: #resumeAfterStepError.
		aMenu addLine].

	aMenu add: 'inspect morph' action: #inspectInMorphic:.
	aMenu add: 'inspect owner chain' action: #inspectOwnerChain.
	Smalltalk isMorphic ifFalse:
		[aMenu add: 'inspect morph (in MVC)' action: #inspect].

	(self isKindOf: MorphicModel) ifTrue:
		[aMenu add: 'inspect model' target: self model action: #inspect].
	(aPlayer _ self player) ifNotNil:
		[aMenu add: 'inspect player' target: aPlayer action: #inspect].

     aMenu add: 'explore morph' target: self selector: #explore.

	aPlayer ifNotNil: [aPlayer class isUniClass ifTrue: [aMenu add: 'browse player class' target: aPlayer action: #browseHierarchy].
		"aMenu add: 'browse player protocol' target: self action: #browseProtocolForPlayer"].

	aMenu add: 'browse morph class' target: self selector: #browseHierarchy.
	"aMenu add: 'browse morph protocol' target: self selector: #haveFullProtocolBrowsed."
	aMenu addLine.
	self addViewingItemsTo: aMenu.
	aMenu 
		add: 'make own subclass' action: #subclassMorph;
		add: 'internal name ' action: #choosePartName;
		add: 'save morph in file'  action: #saveOnFile;
		addLine;
		add: 'call #tempCommand' action: #tempCommand;
		add: 'define #tempCommand' action: #defineTempCommand;
		addLine;

		add: 'control-menu...' target: self selector: #invokeMetaMenu:;
		add: 'edit balloon help' action: #editBalloonHelpText.

	^ aMenu