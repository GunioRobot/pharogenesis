startWiring: event 
	"Start wiring from this pin"

	| origin handle candidates candidate wiringColor wire |
	origin := self wiringEndPoint.
	candidates := OrderedCollection new.
	"Later this could be much faster if we define pinMorphsDo:
		so that it doesn't go too deep and bypasses non-widgets."
	self pasteUpMorph allMorphsDo: 
			[:m | 
			((m isMemberOf: PinMorph) and: [m canDockWith: self]) 
				ifTrue: [candidates add: m]].
	handle := NewHandleMorph new 
				followHand: event hand
				forEachPointDo: 
					[:newPoint | 
					candidate := candidates detect: [:m | m containsPoint: newPoint]
								ifNone: [nil].
					wiringColor := candidate isNil ifTrue: [Color black] ifFalse: [Color red].
					handle
						removeAllMorphs;
						addMorph: (PolygonMorph 
									vertices: (Array with: origin with: newPoint)
									color: Color black
									borderWidth: 1
									borderColor: wiringColor)]
				lastPointDo: 
					[:lastPoint | 
					(self wireTo: candidate) 
						ifTrue: 
							[wire := (WireMorph 
										vertices: (Array with: origin with: lastPoint)
										color: Color black
										borderWidth: 1
										borderColor: Color black) fromPin: self toPin: candidate.
							self pasteUpMorph addMorph: wire.
							self addWire: wire.
							candidate addWire: wire]].
	event hand world addMorph: handle.
	handle startStepping