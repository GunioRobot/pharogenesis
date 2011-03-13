dispatchDropEvent: anEvent with: aMorph
	"Find the appropriate receiver for the event and let it handle it. The dispatch is similar to the default dispatch with one difference: Morphs are given the chance to reject an entire drop operation. If the operation is rejected, no drop will be executed."
	| inside index morphs child localEvt |
	"Try to get out quickly"
	(aMorph fullBounds containsPoint: anEvent cursorPoint)
		ifFalse:[^#rejected].
	"Give aMorph a chance to repel the dropping morph"
	aMorph rejectDropEvent: anEvent.
	anEvent wasHandled ifTrue:[^self].

	"Go looking if any of our submorphs wants it"
	index _ 1.
	inside _ false.
	morphs _ aMorph submorphs.
	[index <= morphs size] whileTrue:[
		child _ morphs at: index.
		localEvt _ anEvent transformedBy: (child transformedFrom: aMorph).
		(child processEvent: localEvt using: self) == #rejected ifFalse:[
			localEvt wasHandled ifTrue:[^anEvent wasHandled: true]. "done"
			inside _ true.
			index _ morphs size]. "break"
		index _ index + 1.
	].

	inside ifFalse:[inside _ aMorph containsPoint: anEvent cursorPoint event: anEvent].
	inside ifTrue:[^aMorph handleEvent: anEvent].
	^#rejected