mouseDown: evt
	"Handle a mouse down event."
	| grabbedMorph handHadHalos |

	grabbedMorph _ self morphToGrab: evt.
	grabbedMorph ifNotNil:[
		grabbedMorph isSticky ifTrue:[^self].
		self isPartsBin ifFalse:[^evt hand grabMorph: grabbedMorph].
		grabbedMorph _ grabbedMorph partRepresented duplicate.
		grabbedMorph restoreSuspendedEventHandler.
		(grabbedMorph fullBounds containsPoint: evt position) 
			ifFalse:[grabbedMorph position: evt position].
		"Note: grabbedMorph is ownerless after duplicate so use #grabMorph:from: instead"
		^ evt hand grabMorph: grabbedMorph from: self].

	(super handlesMouseDown: evt)
		ifTrue:[^super mouseDown: evt].

	handHadHalos _ evt hand halo notNil.

	evt hand removeHalo. "shake off halos"
	evt hand releaseKeyboardFocus. "shake of keyboard foci"

	(evt shiftPressed not
			and:[ self isWorldMorph not ]
			and:[ Preferences easySelection not ])
	ifTrue:[
		"explicitly ignore the event if we're not the world and we'll not select,
		so that we could be picked up if need be"
		evt wasHandled: false.
		^ self.
	].

	( evt shiftPressed or: [ Preferences easySelection ] ) ifTrue:[
		"We'll select on drag, let's decide what to do on click"
		| clickSelector |

		clickSelector := nil.

		evt shiftPressed ifTrue:[
			clickSelector := #findWindow:.
		]
		ifFalse:[
			self isWorldMorph ifTrue:[
				clickSelector := handHadHalos
										ifTrue: [ #delayedInvokeWorldMenu: ]
										ifFalse: [ #invokeWorldMenu: ]
			]
		].

		evt hand 
				waitForClicksOrDrag: self 
				event: evt 
				selectors: { clickSelector. nil. nil. #dragThroughOnDesktop: }
				threshold: 5.
	]
	ifFalse:[
		"We wont select, just bring world menu if I'm the world"
		self isWorldMorph ifTrue:[
			handHadHalos
				ifTrue: [ self delayedInvokeWorldMenu: evt ]
				ifFalse: [ self invokeWorldMenu: evt ]
		]
	].
