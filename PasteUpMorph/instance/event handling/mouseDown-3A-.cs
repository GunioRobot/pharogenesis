mouseDown: evt
	"Handle a mouse down event."
	| grabbedMorph handHadHalos |
	grabbedMorph _ self morphToGrab: evt.
	grabbedMorph ifNotNil:[
		grabbedMorph isSticky ifTrue:[^self].
		self isPartsBin ifFalse:[^evt hand grabMorph: grabbedMorph].
		grabbedMorph _ grabbedMorph partRepresented duplicate.
		grabbedMorph restoreSuspendedEventHandler.
		(grabbedMorph fullBounds containsPoint: evt position) 
			ifFalse:[grabbedMorph position: evt position].
		"Note: grabbedMorph is ownerless after duplicate so use #grabMorph:from: instead"
		^evt hand grabMorph: grabbedMorph from: self].

	(super handlesMouseDown: evt)
		ifTrue:[^super mouseDown: evt].
	handHadHalos _ evt hand halo notNil.
	evt hand halo: nil. "shake off halos"
	evt hand releaseKeyboardFocus. "shake of keyboard foci"
	evt shiftPressed ifTrue:[
		^evt hand 
			waitForClicksOrDrag: self 
			event: evt 
			selectors: { #findWindow:. nil. #dragThroughOnDesktop:}
			threshold: 5].
	self isWorldMorph ifTrue: [
		handHadHalos ifTrue: [^self addAlarm: #invokeWorldMenu: with: evt after: 200].
		^self invokeWorldMenu: evt
	].
	"otherwise, explicitly ignore the event if we're not the world,
	so that we could be picked up if need be"
	self isWorldMorph ifFalse:[evt wasHandled: false].
