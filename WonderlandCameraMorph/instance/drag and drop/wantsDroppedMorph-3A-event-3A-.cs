wantsDroppedMorph: aMorph event: evt
	"Return true if the receiver wishes to accept the given morph, which is being dropped by a hand in response to the given event. The default implementation returns false.
NOTE: the event is assumed to be in global (world) coordinates."
	| pt |
	(super wantsDroppedMorph: aMorph event: evt) ifFalse:[^false].
	pt _ self transformFromWorld globalPointToLocal: evt cursorPoint.
	(myCamera pickAt: pt) == nil ifTrue:[^false].
	^true