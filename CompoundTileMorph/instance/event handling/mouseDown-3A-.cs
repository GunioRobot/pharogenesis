mouseDown: evt 
	"Pretend we picked up the tile and then put it down for a trial  
	positioning."
	"The essence of ScriptEditor mouseEnter:"
	| ed ss guyToTake |
"	self isPartsDonor ifTrue:[
		dup _ self duplicate.
		evt hand attachMorph: dup.
		dup position: evt position.
		^self].
	submorphs isEmpty 			never true
		ifTrue: [^ self].
"
	(ed _ self enclosingEditor) ifNil: [^evt hand grabMorph: self].

	guyToTake _ self.
	owner class == TilePadMorph
		ifTrue: ["picking me out of another phrase"
			(ss _ submorphs first) class == TilePadMorph
				ifTrue: [ss _ ss submorphs first].
			guyToTake _  ss veryDeepCopy].
	evt hand grabMorph: guyToTake.
	ed startStepping.
	ed mouseEnterDragging: evt.
	ed setProperty: #justPickedUpPhrase toValue: true.