mouseDown: evt 
	"Handle a mouse-down on the receiver"

	| ed guyToTake dup enclosingPhrase |
	self isPartsDonor ifTrue:
		[dup _ self duplicate.
		dup eventHandler: nil.   "Remove viewer-related evt mouseover feedback"
		evt hand attachMorph: dup.
		dup position: evt position.
		"So that the drag vs. click logic works"
		dup formerPosition: evt position.
		^ self].
	submorphs isEmpty
		ifTrue: [^ self].

	guyToTake _ self.
	[(enclosingPhrase _ guyToTake ownerThatIsA: PhraseTileMorph) notNil] whileTrue:
		[guyToTake _ enclosingPhrase].  "This logic always grabs the outermost phrase, for now anyway"
	
	"the below had comment: 'picking me out of another phrase'"
	"owner class == TilePadMorph
		ifTrue:
			[(ss _ submorphs first) class == TilePadMorph
				ifTrue: [ss _ ss submorphs first].
			guyToTake _  ss veryDeepCopy]."

	(ed _ self enclosingEditor) ifNil: [^ evt hand grabMorph: guyToTake].
	evt hand grabMorph: guyToTake.
	ed startStepping.
	ed mouseEnterDragging: evt.
	ed setProperty: #justPickedUpPhrase toValue: true.
