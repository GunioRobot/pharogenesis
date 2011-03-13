processMouseOver: anEvent
	"Re-establish the z-order for all morphs wrt the given event"
	| hand localEvt focus evt |
	hand _ anEvent hand.
	leftMorphs _ mouseOverMorphs asIdentitySet.
	"Assume some coherence for the number of objects in over list"
	overMorphs _ WriteStream on: (Array new: leftMorphs size).
	enteredMorphs _ WriteStream on: #().
	"Now go looking for eventual mouse overs"
	hand handleEvent: anEvent asMouseOver.
	"Get out early if there's no change"
	(leftMorphs size = 0 and:[enteredMorphs position = 0]) 
		ifTrue:[^leftMorphs _ enteredMorphs _ overMorphs _ nil].
	focus _ hand mouseFocus.
	"Send #mouseLeave as appropriate"
	evt _ anEvent asMouseLeave.
	"Keep the order of the left morphs by recreating it from the mouseOverMorphs"
	leftMorphs size > 1 ifTrue:[leftMorphs _ mouseOverMorphs select:[:m| leftMorphs includes: m]].
	leftMorphs do:[:m|
		(m hasOwner: focus) 
			ifTrue:[localEvt _ evt transformedBy: (m transformedFrom: hand).
					m handleEvent: localEvt]
			ifFalse:[overMorphs nextPut: m]].
	"Send #mouseEnter as appropriate"
	evt _ anEvent asMouseEnter.
	enteredMorphs _ enteredMorphs contents.
	enteredMorphs reverseDo:[:m|
		(m hasOwner: focus) 
			ifTrue:[	localEvt _ evt transformedBy: (m transformedFrom: hand).
					m handleEvent: localEvt]].
	"And remember the over list"
	mouseOverMorphs _ overMorphs contents.
	leftMorphs _ enteredMorphs _ overMorphs _ nil.
