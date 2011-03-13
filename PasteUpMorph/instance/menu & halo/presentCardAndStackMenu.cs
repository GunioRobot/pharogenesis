presentCardAndStackMenu
	"Put up a menu holding card/stack-related options."

	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.		
	aMenu addStayUpItem.
	aMenu addTitle: 'card und stack'.
	aMenu add: 'add new card' action: #insertCard.
	aMenu add: 'delete this card' action: #deleteCard.
	aMenu add: 'go to next card' action: #goToNextCardInStack.
	aMenu add: 'go to previous card' action: #goToPreviousCardInStack.
	aMenu addLine.
	aMenu add: 'show foreground objects' action: #showForegroundObjects.
	aMenu add: 'show background objects' action: #showBackgroundObjects.
	aMenu add: 'show designations' action: #showDesignationsOfObjects.
	aMenu add: 'explain designations'  action: #explainDesignations.
	aMenu popUpInWorld: (self world ifNil: [self currentWorld])