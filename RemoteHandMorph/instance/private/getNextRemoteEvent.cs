getNextRemoteEvent
	"Return the next remote event, or nil if the receive buffer does not contain a full event record. An event record is the storeString for a MorphicEvent terminated by a <CR> character."

	| i s evt |
	self receiveData.
	receiveBuffer isEmpty ifTrue: [^ nil].

	i _ receiveBuffer indexOf: Character cr ifAbsent: [^ nil].
	s _ receiveBuffer copyFrom: 1 to: i - 1.
	receiveBuffer _ receiveBuffer copyFrom: i + 1 to: receiveBuffer size.
	evt _ (MorphicEvent readFromString: s).
	evt ifNil:[^nil].
	evt setHand: self.
	evt isKeyboard ifTrue:[evt setPosition: self position].
	^evt resetHandlerFields