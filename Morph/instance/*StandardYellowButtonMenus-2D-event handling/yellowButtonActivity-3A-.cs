yellowButtonActivity: shiftState
	"Find me or my outermost owner that has items to add to a yellow button menu.
	shiftState is true if the shift was pressed.
	Otherwise, build a menu that contains the contributions from myself and my interested submorphs,
	and present it to the user."

	| aMenu outerOwner |
	outerOwner := self outermostOwnerWithYellowButtonMenu.
	outerOwner ifNil: [ ^self ].
	outerOwner ~~ self ifTrue: [^outerOwner yellowButtonActivity: shiftState ].

	aMenu := MenuMorph new defaultTarget: self.
	aMenu addTitle: self externalName.
	self addNestedYellowButtonItemsTo: aMenu event: ActiveEvent.
	aMenu popUpInWorld: self currentWorld.
 
