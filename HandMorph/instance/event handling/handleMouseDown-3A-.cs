handleMouseDown: evt
	"Dispatch a mouseDown event."

	| m localEvt rootForGrab aHalo |
	"if carrying morphs, just drop them"
	self hasSubmorphs ifTrue: [^ self dropMorphsEvent: evt].

	clickState ~~ #idle ifTrue: [^ self checkForDoubleClick: evt].

	m _ self recipientForMouseDown:
			(gridOn  "Don't grid when determining recipient"
				ifTrue: ["Should really use original cursorPoint, but this should do"
						evt copy setCursorPoint: Sensor cursorPoint]
				ifFalse: [evt]).
	m ifNotNil:
		[aHalo _ self world haloMorphOrNil.
		(aHalo == nil or: [aHalo staysUpWhenMouseIsDownIn: m])
			ifFalse: [self world abandonAllHalos].
		m deleteBalloon.
		(m handlesMouseDown: evt)
			ifTrue:
				["start a mouse transaction on m"
				(self newMouseFocus: m) ifNil: [^ self].
				localEvt _ self transformEvent: evt.
				targetOffset _ localEvt cursorPoint - m position.
				m mouseDown: localEvt.
				clickState == #firstClickDown
					ifTrue: [clickClient click: firstClickEvent]
					ifFalse:
					["ensure that at least one mouseMove: is reported for each mouse transaction:"
					m mouseMove: (localEvt copy setType: #mouseMove).
					(m handlesMouseOverDragging: localEvt) ifTrue:
						["If m also handles dragOver, enter it in the list"
						dragOverMorphs add: m.
						mouseOverMorphs remove: m ifAbsent: []]]]
			ifFalse:
				["grab m by the appropriate root"
				menuTargetOffset _ targetOffset _ evt cursorPoint.
				rootForGrab _ m rootForGrabOf: m.
				rootForGrab
					ifNotNil:
						[self grabMorph: rootForGrab]
					ifNil:
						[self newMouseFocus: m   "trigger automatic viewing, for example"]].
		mouseOverTimes removeKey: m ifAbsent: []]