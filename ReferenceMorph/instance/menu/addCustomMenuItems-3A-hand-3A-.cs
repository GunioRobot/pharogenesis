addCustomMenuItems: aCustomMenu hand: aHandMorph
	"Add morph-specific items to the menu for the hand"

	| sketch |
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	self isCurrentlyTextual
		ifTrue:
			[aCustomMenu add: 'change label wording...' action: #changeTabText.
			aCustomMenu add: 'use graphical label' action: #useGraphicalTab]
		ifFalse:
			[aCustomMenu add: 'use textual label' action: #useTextualTab.
			aCustomMenu add: 'choose graphic...' action: #changeTabGraphic.
			(sketch _ self findA: SketchMorph) ifNotNil:
				[aCustomMenu add: 'repaint' target: sketch action: #editDrawing]]