processMouseOver: anEvent 
	"Re-establish the z-order for all morphs wrt the given event"

	| hand localEvt focus evt |
	hand := anEvent hand.
	leftMorphs := mouseOverMorphs asIdentitySet.
	"Assume some coherence for the number of objects in over list"
	overMorphs := WriteStream on: (Array new: leftMorphs size).
	enteredMorphs := WriteStream on: #().
	"Now go looking for eventual mouse overs"
	hand handleEvent: anEvent asMouseOver.
	"Get out early if there's no change"
	(leftMorphs isEmpty and: [enteredMorphs position = 0]) 
		ifTrue: [^leftMorphs := enteredMorphs := overMorphs := nil].
	focus := hand mouseFocus.
	"Send #mouseLeave as appropriate"
	evt := anEvent asMouseLeave.
	"Keep the order of the left morphs by recreating it from the mouseOverMorphs"
	leftMorphs size > 1 
		ifTrue: [leftMorphs := mouseOverMorphs select: [:m | leftMorphs includes: m]].
	leftMorphs do: 
			[:m | 
			(m == focus or: [m hasOwner: focus]) 
				ifTrue: 
					[localEvt := evt transformedBy: (m transformedFrom: hand).
					m handleEvent: localEvt]
				ifFalse: [overMorphs nextPut: m]].
	"Send #mouseEnter as appropriate"
	evt := anEvent asMouseEnter.
	enteredMorphs ifNil: 
			["inform: was called in handleEvent:"

			^leftMorphs := enteredMorphs := overMorphs := nil].
	enteredMorphs := enteredMorphs contents.
	enteredMorphs reverseDo: 
			[:m | 
			(m == focus or: [m hasOwner: focus]) 
				ifTrue: 
					[localEvt := evt transformedBy: (m transformedFrom: hand).
					m handleEvent: localEvt]].
	"And remember the over list"
	overMorphs ifNil: 
			["inform: was called in handleEvent:"

			^leftMorphs := enteredMorphs := overMorphs := nil].
	mouseOverMorphs := overMorphs contents.
	leftMorphs := enteredMorphs := overMorphs := nil