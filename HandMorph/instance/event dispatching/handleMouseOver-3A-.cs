handleMouseOver: evt
	| p roots mList allMouseOvers leftMorphs enteredMorphs now t oldHalo balloonHelpEnabled mouseOverHalosEnabled |
	owner ifNil: [^ self].  "this hand is not in a world"
	balloonHelpEnabled _ self world balloonHelpEnabled & evt anyButtonPressed not.
	mouseOverHalosEnabled _ self world mouseOverHalosEnabled & evt anyButtonPressed not.
	p _ evt cursorPoint.
	roots _ owner rootMorphsAt: p.  "root morphs in world"
	roots size > 0
		ifTrue: [mList _ roots first unlockedMorphsAt: p]
		ifFalse: [mList _ EmptyArray].

	now _ Time millisecondClockValue.

	"Make a list of all potential mouse-overs..."
	allMouseOvers _ mList , submorphs select:
		[:m | ((mouseOverHalosEnabled and: [m wantsHalo]) or: [balloonHelpEnabled and: [m wantsBalloon]])  "To start a timer"
					or: [m handlesMouseOver: evt]  "To send mouseEnter:"].

	"Notify and remove any mouse-overs that have just been left..."
	leftMorphs _ mouseOverMorphs select: [:m | (allMouseOvers includes: m) not].
	leftMorphs do: [:m |
		mouseOverMorphs remove: m.	"OK to call me recursively"
		m wantsBalloon ifTrue: [m deleteBalloon].
		m mouseLeave: (evt transformedBy: (m transformFrom: self)).
		mouseOverTimes ifNotNil: [mouseOverTimes removeKey: m ifAbsent: [] ]].

	"Add any new mouse-overs and send mouseEnter: and/or start timers..."
	enteredMorphs _ allMouseOvers select: [:m | (mouseOverMorphs includes: m) not].
	enteredMorphs do: [:m |
		mouseOverMorphs add: m.	"OK to call me recursively"
		(m handlesMouseOver: evt) ifTrue:
			[m mouseEnter: (evt transformedBy: (m transformFrom: self))].
		(m wantsHalo or: [m wantsBalloon]) ifTrue:
			[mouseOverTimes ifNotNil: [mouseOverTimes at: m put: now]]].

mouseOverTimes ifNotNil:
	[mouseOverTimes keys do:
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
										self popUpHalo: evt.
										(balloonHelpEnabled and: [m wantsBalloon]) ifTrue:
											["...and reschedule balloon after longer linger"
											mouseOverTimes at: m put: now]]
								ifFalse: ["Halo for m is already up, so show balloon"
										(balloonHelpEnabled and: [m wantsBalloon])
											ifTrue: [m showBalloon]]]
					ifFalse:
						[(balloonHelpEnabled and: [m wantsBalloon])
							ifTrue: [m showBalloon]]]]]]