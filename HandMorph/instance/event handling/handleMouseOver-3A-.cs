handleMouseOver: evt
	| mList allMouseOvers leftMorphs enteredMorphs now t oldHalo balloonHelpEnabled |
	owner ifNil: [^ self].
	balloonHelpEnabled _ Preferences balloonHelpEnabled.

	"Start with a list consisting of the topmost unlocked morph in the
	innermost frame (pasteUp), and all of its containers in that frame."
	mList _ self mouseOverList: evt.

	now _ Time millisecondClockValue.

	"Make a list of all potential mouse-overs..."
	allMouseOvers _ mList select:
		[:m | m wantsHalo or: [(balloonHelpEnabled and: [m wantsBalloon])  "To start a timer"
			or: [m handlesMouseOver: (evt transformedBy: (m transformFrom: self))]  "To send mouseEnter:"]].
	leftMorphs _ mouseOverMorphs select: [:m | (allMouseOvers includes: m) not].
	enteredMorphs _ allMouseOvers select: [:m | (mouseOverMorphs includes: m) not].

	"Notify and remove any mouse-overs that have just been left..."
	leftMorphs do: [:m |
		mouseOverMorphs remove: m.
		m wantsBalloon ifTrue: [m deleteBalloon].
		m mouseLeave: (evt transformedBy: (m transformFrom: self)).
		mouseOverTimes removeKey: m ifAbsent: [] ].

	"Add any new mouse-overs and send mouseEnter: and/or start timers..."
	enteredMorphs do: [:m |
		mouseOverMorphs add: m.
		dragOverMorphs remove: m ifAbsent: [].  "Cant be in two places at once"
		(m handlesMouseOver: evt) ifTrue:
			[m mouseEnter: (evt transformedBy: (m transformFrom: self))].
		(m wantsHalo or: [m wantsBalloon]) ifTrue:
			[mouseOverTimes at: m put: now]].

	mouseOverTimes keys do:
		[:m | "Check pending timers for lingering"
		t _ mouseOverTimes at: m.
		(now < t "rollover" or: [now > (t+800)]) ifTrue:
			["Yes we have lingered for 0.8 seconds..."
			mouseOverTimes removeKey: m.
			m owner ifNotNil:  "Not deleted during linger (--it happens ;--)"
				[m wantsHalo
					ifTrue: [oldHalo _ m world haloMorphOrNil.
							(oldHalo == nil or: [oldHalo target ~~ m])
								ifTrue: ["Put up halo for m"
										self popUpHaloFor: m event: evt.
										(balloonHelpEnabled and: [m wantsBalloon]) ifTrue:
											["...and reschedule balloon after longer linger"
											mouseOverTimes at: m put: now]]
								ifFalse: ["Halo for m is already up, so show balloon"
										(balloonHelpEnabled and: [m wantsBalloon])
											ifTrue: [m showBalloon: m balloonText]]]
					ifFalse:
						[(balloonHelpEnabled and: [m wantsBalloon])
							ifTrue: [m showBalloon: m balloonText]]]]]