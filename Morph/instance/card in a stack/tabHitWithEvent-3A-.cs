tabHitWithEvent: anEvent
	"The tab key was hit.  The keyboard focus has referred this event to me, though this perhaps seems rather backwards.  Anyway, the assumption is that I have the property #tabAmongFields, so now the task is to tab to the next field."

	| currentFocus fieldList anIndex itemToHighlight variableBearingMorphs otherAmenableMorphs |
	currentFocus _ anEvent hand keyboardFocus.
	fieldList _ self allMorphs select:
		[:aMorph | (aMorph wouldAcceptKeyboardFocusUponTab) and: [aMorph isLocked not]].

	variableBearingMorphs _ self player isNil
										ifTrue:[#()]
										ifFalse:[self player class variableDocks collect: [:vd | vd definingMorph] thenSelect: [:m | m isInWorld]].
	otherAmenableMorphs _ (self allMorphs select:
		[:aMorph | (aMorph wouldAcceptKeyboardFocusUponTab) and: [aMorph isLocked not]])
			copyWithoutAll: variableBearingMorphs.
	fieldList _ variableBearingMorphs, otherAmenableMorphs.

	anIndex _ fieldList indexOf: currentFocus ifAbsent: [nil].
	itemToHighlight _ fieldList atWrap: 
		(anIndex ifNotNil: [anEvent shiftPressed ifTrue: [anIndex - 1] ifFalse: [anIndex + 1]]
				ifNil: [1]).
	anEvent hand newKeyboardFocus: itemToHighlight. self flag: #arNote. "really???"
	itemToHighlight editor selectAll.
	itemToHighlight invalidRect: itemToHighlight bounds 