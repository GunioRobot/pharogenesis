getBoundsForActor: anActor
	"Return the 2D bounds of the actor as seen by the receiver"
	bounds == nil ifTrue:[^nil].
	^bounds at: anActor ifAbsent:[nil]