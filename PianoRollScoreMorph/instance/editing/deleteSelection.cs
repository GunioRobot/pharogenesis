deleteSelection

	| selMorphs priorEvent x |
	(selection == nil or: [selection second = 0]) ifTrue: [^ self].
	score cutSelection: selection.
	selection second > 1
		ifTrue: [selection at: 2 put: selection second - 1.
				selection at: 3 put: selection second.
				priorEvent _ (score tracks at: selection first) at: selection second.
				(x _ self xForTime: priorEvent time) < (self left + 30) ifTrue:
					[self autoScrollForX: x - (30 + self width // 4)]]
		ifFalse: [selection _ nil].
	scorePlayer updateDuration.
	self rebuildFromScore.
	selMorphs _ self submorphsSatisfying:
						[:m | (m isKindOf: PianoRollNoteMorph) and: [m selected]].
	selMorphs isEmpty ifFalse: [(selMorphs last noteOfDuration: 0.3) play]