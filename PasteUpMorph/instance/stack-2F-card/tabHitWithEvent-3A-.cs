tabHitWithEvent: anEvent
	"The tab key was hit. The keyboard focus has referred this event to me, though this perhaps seems rather backwards.  Anyway, the assumption is that I have the property #tabAmongFields, so now the task is to tab to the next field"

	| currentFocus fieldList anIndex itemToHighlight |

	currentFocus _ anEvent hand keyboardFocus.
	fieldList _ self allMorphs select:
		[:aMorph | (aMorph wouldAcceptKeyboardFocusUponTab) and: [aMorph isLocked not]].

	anIndex _ fieldList indexOf: currentFocus ifAbsent: [nil].
	itemToHighlight _ fieldList atWrap: 
		(anIndex ifNotNil: [anEvent shiftPressed ifTrue: [anIndex - 1] ifFalse: [anIndex + 1]]
				ifNil: [1]).
	anEvent hand newKeyboardFocus: itemToHighlight. self flag: #arNote. "really???"
	itemToHighlight editor selectAll.
	itemToHighlight invalidRect: itemToHighlight bounds 