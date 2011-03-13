buildDebugMenu: aHand
	"Answer a debugging menu for the receiver. 
	 The hand argument is seemingly historical and plays no role presently"

	| aMenu |
	aMenu := MenuMorph new defaultTarget: self.
	aMenu addStayUpItem.
	(self hasProperty: #errorOnDraw) ifTrue:
		[aMenu add: 'start drawing again' translated action: #resumeAfterDrawError.
		aMenu addLine].
	(self hasProperty: #errorOnStep) ifTrue:
		[aMenu add: 'start stepping again' translated action: #resumeAfterStepError.
		aMenu addLine].

	aMenu add: 'inspect morph' translated action: #inspectInMorphic:.
	aMenu add: 'inspect owner chain' translated action: #inspectOwnerChain.
	self isMorphicModel ifTrue:
		[aMenu add: 'inspect model' translated target: self model action: #inspect].
     aMenu add: 'explore morph' translated target: self selector: #explore.
	aMenu addLine.
	aMenu add: 'browse morph class' translated target: self selector: #browseHierarchy.
	(self isMorphicModel)
		ifTrue: [aMenu
				add: 'browse model class'
				target: self model
				selector: #browseHierarchy].
	aMenu addLine.

	self addViewingItemsTo: aMenu.
	aMenu 
		add: 'make own subclass' translated action: #subclassMorph;
		addLine;
		add: 'call #tempCommand' translated action: #tempCommand;
		add: 'define #tempCommand' translated action: #defineTempCommand;
		addLine.
	^ aMenu