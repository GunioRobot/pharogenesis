step
	"Handle hand enter and exits."
	"Details: The normal mouseOver: mechanism is disabled (for good reasons!) when the mouse button is down and/or the hand is carrying some object. This exceptional case is handled using the step mechanism."

	self inPartsBin ifTrue: [^ self].  "inactive when in parts bin"
	handsOverMe ifNil: [handsOverMe _ IdentitySet new].  "lazy initialization"
	self world hands do: [:h |
		(self containsPoint: h position)
			ifTrue: [
				(handsOverMe includes: h) ifFalse: [
					self handEntering: h.
					handsOverMe add: h]]
			ifFalse: [
				(handsOverMe includes: h) ifTrue: [
					self handExiting: h.
					handsOverMe remove: h]]].
