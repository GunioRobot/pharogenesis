listMenu: aMenu shifted: shiftState
	aMenu title: 'Test Cases'.
	aMenu add: 'select all' target: self selector: #selectAll.
	aMenu add: 'deselect all' target: self selector: #deselectAll.
	aMenu add: 'toggle selections' target: self selector: #toggleSelections.
	aMenu add: 'filter' target: self selector: #setFilter.
	selectedSuite > 0 ifTrue: [ | cls |
		cls _ (tests at: selectedSuite ifAbsent: ['']) copyUpTo: Character space.
		cls _ cls asSymbol.
		cls _ (Smalltalk at: cls ifAbsent: []).
		cls ifNotNil: [ | mtc |
			aMenu addLine.
			aMenu add: 'browse' target: self selector: #browse: argument: cls.
			mtc _ Smalltalk at: #MorphicTestCase ifAbsent: [ ].
			(mtc notNil and: [ cls inheritsFrom: mtc ]) ifTrue: [
				aMenu add: 'record interaction' target: self selector: #recordInteractionFor: argument: cls.
			].
		].
	].
	shiftState ifTrue: [
		aMenu addLine.
		testsList addCustomMenuItems: aMenu hand: ActiveHand.
	].
	^aMenu
