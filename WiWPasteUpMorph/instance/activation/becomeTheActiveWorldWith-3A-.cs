becomeTheActiveWorldWith: evt
	"Make the receiver become the active world, and give its hand the event provided, if not nil"

	| outerWorld |
	World == self ifTrue: [^ self].
	worldState resetDamageRecorder.	"since we may have moved, old data no longer valid"
	hostWindow setStripeColorsFrom: Color green.
	worldState canvas: nil.	"safer to start from scratch"
	displayChangeSignatureOnEntry _ Display displayChangeSignature.

	"Messy stuff to clear flaps from outer world"
	Flaps globalFlapTabsIfAny do: [:f | f changed].
	outerWorld _ World.
	World _ self.
	self installFlaps.
	World _ outerWorld.
	outerWorld displayWorld.
	World _ self.

	self viewBox: hostWindow panelRect.
	self startSteppingSubmorphsOf: self.
	self changed.
	pendingEvent _ nil.
	evt ifNotNil: [self primaryHand handleEvent: (evt setHand: self primaryHand)].

