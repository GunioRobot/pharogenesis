mouseDown: evt
	"Pretend we picked up the tile and then put it down for a trial positioning."

	"The essence of ScriptEditor mouseEnter:"
	| ed ss |
	owner class == TilePadMorph 
		ifTrue: ["picking me out of another phrase"
			(ss _ submorphs first) class == TilePadMorph ifTrue: [
					ss _ ss submorphs first].
			owner addMorph: (ss fullCopy)].

	(ed _ self enclosingEditor) ifNotNil:
		[evt hand grabMorph: self.
		ed startStepping].