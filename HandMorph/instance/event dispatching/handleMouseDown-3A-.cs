handleMouseDown: evt
	"Dispatch a mouseDown event."

	| m localEvt rootForGrab aHalo |
	"if carrying morphs, just drop them"
	self hasSubmorphs ifTrue: [^ self dropMorphsEvent: evt].

	clickState ~~ #idle ifTrue: [^ self checkForDoubleClick: evt].

	m _ self recipientForMouseDown: evt.
	m ifNotNil:
		[aHalo _ self world haloMorphOrNil.
		(aHalo == nil or: [aHalo staysUpWhenMouseIsDownIn: m])
			ifFalse: [self world abandonAllHalos].
		m deleteBalloon.
		(m handlesMouseDown: evt)
			ifTrue:
				["start a mouse transaction on m"
				mouseDownMorph _ m.
				eventTransform _ m transformFrom: self.
				localEvt _ self transformEvent: evt.
				targetOffset _ localEvt cursorPoint - m position.
				m mouseDown: localEvt.
				"ensure that at least one mouseMove: is reported
				 for each mouse transaction:"
				m mouseMove: (localEvt copy setType: #mouseMove)]
			ifFalse:
				["grab m by the appropriate root"
				menuTargetOffset _ targetOffset _ evt cursorPoint.
				rootForGrab _ m rootForGrabOf: m.
				rootForGrab ifNotNil: [self grabMorph: rootForGrab]].
		mouseOverTimes ifNotNil: [mouseOverTimes removeKey: m ifAbsent: []]].
