processEvent: anEvent using: defaultDispatcher
	"Reimplemented to install the receiver as the new ActiveWorld if it is one"
	| priorWorld result |
	self isWorldMorph ifFalse:[^super processEvent: anEvent using: defaultDispatcher].
	priorWorld _ ActiveWorld.
	ActiveWorld _ self.
	result _ super processEvent: anEvent using: defaultDispatcher.
	ActiveWorld _ priorWorld.
	^result