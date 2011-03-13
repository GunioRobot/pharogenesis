encounteredAtTime: ticks inScorePlayer: scorePlayer atIndex: index inEventTrack: track secsPerTick: secsPerTick

	| nextAmbient m nextDurationInMs program now finalMark thisPage nextPage |

	self gotoMark.
	nextAmbient _ nil.
	index to: track size do: [ :i |
		(nextAmbient isNil and: [((m _ track at: i) morph) isKindOf: self class]) ifTrue: [
			nextAmbient _ m.
		].
	].
	nextAmbient ifNil: [^self].
	nextDurationInMs _ (nextAmbient time - ticks * secsPerTick * 1000) rounded.
	finalMark _ nextAmbient morph.
	thisPage _ self valueOfProperty: #bookPage.
	nextPage _ finalMark valueOfProperty: #bookPage.
	(thisPage = nextPage or: [thisPage isNil | nextPage isNil]) ifFalse: [^finalMark gotoMark].
	now _ Time millisecondClockValue.
	program _ Dictionary new.
	program
		at: #startTime put: now;
		at: #endTime put: now + nextDurationInMs;
		at: #startPoint put: (self valueOfProperty: #cameraPoint);
		at: #endPoint put: (finalMark valueOfProperty: #cameraPoint);
		at: #startZoom put: (self valueOfProperty: #cameraScale);
		at: #endZoom put: (finalMark valueOfProperty: #cameraScale).

	self cameraController setProgrammedMoves: {program}.

