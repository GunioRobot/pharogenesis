dispatchDefault: anEvent with: aMorph
	"Dispatch the given event. The event will be passed to the front-most visible submorph that contains the position wrt. to the event."
	| localEvt index child morphs inside |
	"See if we're fully outside aMorphs bounds"
	(aMorph fullBounds containsPoint: anEvent position) ifFalse:[^#rejected]. "outside"
	"Traverse children"
	index _ 1.
	morphs _ aMorph submorphs.
	inside _ false.
	[index <= morphs size] whileTrue:[
		child _ morphs at: index.
		localEvt _ anEvent transformedBy: (child transformedFrom: aMorph).
		(child processEvent: localEvt using: self) == #rejected ifFalse:[
			"Not rejected. The event was in some submorph of the receiver"
			inside _ true.
			localEvt wasHandled ifTrue:[anEvent copyHandlerState: localEvt].
			index _ morphs size. "break"
		].
		index _ index + 1.
	].

	"Check for being inside the receiver"
	inside ifFalse:[inside _ aMorph containsPoint: anEvent position event: anEvent].
	inside ifTrue:[^aMorph handleEvent: anEvent].
	^#rejected
