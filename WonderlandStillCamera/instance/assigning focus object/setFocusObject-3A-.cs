setFocusObject: anActor
	"Assign the object in the Wonderland that the camera should focus on"

	| boundingBox origin corner center maxDimension distance frustum |

	focusObject _ anActor.

	anActor ifNotNil: [

			(anActor isKindOf: WonderlandActor)
				ifTrue: [ boundingBox _ anActor getBoundingBox.
						  origin _ boundingBox origin.
						  corner _ boundingBox corner.
						  center _ (origin + corner) / 2.0.

						  self turnToRightNow: { 0. 0. 0} asSeenBy: anActor undoable: false.
						  self turnRightNow: left numberOfTurns: 0.5 undoable: false.

						  maxDimension _ (((corner x - center x) max: (corner y - center y))
												max: (center x - origin x))
													max: (center y - origin y).

						  frustum _ self getFrustum.
						  distance _ ((frustum near) * maxDimension / (0.7 * (frustum right)))
										+ (corner z).

						  self moveToRightNow: { center x.
												  center y.
												  distance }
								asSeenBy: anActor undoable: false.

						  self moveRightNow: right distance: (maxDimension) undoable: false.
						  self moveRightNow: up distance: (maxDimension) undoable: false.
						  self turnRightNow: left numberOfTurns:
								((((maxDimension) arcTan: distance) radiansToDegrees) / 360.0)
								undoable: false.
						  self turnRightNow: down numberOfTurns:
								((((maxDimension) arcTan: distance) radiansToDegrees) / 360.0)
								undoable: false.
						]

				ifFalse: [ self moveToRightNow: { -1.5. 0.5. 2.6 } asSeenBy: anActor undoable: false.
						  self pointAtRightNow: { 0. 0. 0 } undoable: false.
						  self moveRightNow: back distance: 20 undoable: false ].

		].

	myMorph changed.