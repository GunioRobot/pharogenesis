notePenDown: penDown forPlayer: player at: location
	"Note that a morph has just moved with its pen down, begining at startPoint.
	Only used in conjunction with Preferences batchPenTrails."

	| startLoc |
	lastTurtlePositions ifNil: [lastTurtlePositions _ IdentityDictionary new].
	penDown
		ifTrue: ["Putting the Pen down -- record current location"
				(lastTurtlePositions includesKey: player) ifFalse:
					[lastTurtlePositions at: player put: location]]
		ifFalse: ["Picking the Pen up -- draw to current location and remove"
				(startLoc _ lastTurtlePositions at: player ifAbsent: [nil]) ifNotNil:
					[self drawPenTrailFor: player costume
							from: startLoc to: location].
				lastTurtlePositions removeKey: player ifAbsent: []]