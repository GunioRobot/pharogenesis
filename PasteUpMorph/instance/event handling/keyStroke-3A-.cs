keyStroke: anEvent
	"A keystroke has been made.  Service event handlers and, if it's a keystroke presented to the world, dispatch it to #unfocusedKeystroke:"

	super keyStroke: anEvent.  "Give event handlers a chance"
	(anEvent keyCharacter == Character tab) ifTrue:
		[(self hasProperty: #tabAmongFields)
			ifTrue:[^ self tabHitWithEvent: anEvent]].
	self isWorldMorph ifTrue:
		[self keystrokeInWorld: anEvent]