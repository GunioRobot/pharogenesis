dropMorph: aMorph event: anEvent
	"Drop the given morph which was carried by the hand"
	| event dropped |
	self privateRemoveMorph: aMorph.
	dropped _ aMorph.
	(dropped hasProperty: #addedFlexAtGrab) 
		ifTrue:[dropped _ aMorph removeFlexShell].
	event _ DropEvent new setPosition: self position contents: dropped hand: self.
	owner processEvent: event.
	event wasHandled ifFalse:[aMorph rejectDropMorphEvent: event].
	aMorph owner == self ifTrue:[aMorph delete].
	self mouseOverHandler processMouseOver: anEvent.