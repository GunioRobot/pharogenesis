onMouseMove: event
	"The default response to mouse motion events"

	| deltaX deltaY screenPos scenePos depth camera evt |

	deltaX _ event getCursorDelta x.
	deltaY _ event getCursorDelta y.
	camera _ event getCamera.
	evt _ event getMorphicEvent.
	(evt shiftPressed)
		ifTrue: [ (evt controlKeyPressed)
					ifTrue: [
						"If both shift and control are pressed, tumble the bunny"
							scenePos _ self getPosition.
							self moveToRightNow: { 0. 0. 0 } asSeenBy: (myWonderland getScene)
									undoable: false.
							self turnRightNow: down numberOfTurns: (deltaY * 0.01)
									asSeenBy: (myWonderland getScene) undoable: false.
							self turnRightNow: left numberOfTurns: (deltaX * 0.01)
									asSeenBy: (myWonderland getScene) undoable: false.
							self moveToRightNow: scenePos undoable: false.

							]

					ifFalse: [
						"If only shift is pressed move the actor up/down"
						screenPos _ (self getPositionInPixels: camera) + (0@deltaY).
						scenePos _ camera transformScreenPointToScenePoint: screenPos
												atDepthOf: self.
						self moveToRightNow: (scenePos) asSeenBy: (myWonderland getScene)
								undoable: false.
							].
				]
		ifFalse: [ (evt controlKeyPressed)
					ifTrue: [
							scenePos _ self getPosition.
							self moveToRightNow: { 0. 0. 0 } asSeenBy: (myWonderland getScene)
									undoable: false.
							self turnRightNow: left numberOfTurns: (deltaX * 0.01)
									asSeenBy: (myWonderland getScene) undoable: false.
							self moveToRightNow: scenePos undoable: false.
							]
					ifFalse: [
						"If no modifier keys are held down, move the actor forward-back
						and left-right"
						screenPos _ (self getPositionInPixels: camera) + (deltaX@0).
						depth _ ((self getPosition: camera) at: 3) - (deltaY * 0.01).
						scenePos _ camera transformScreenVectorToSceneVector:
							(B3DVector3 x: (screenPos x) y: (screenPos y) z: depth).

						self moveToRightNow: { scenePos at: 1. asIs. scenePos at: 3 }
								asSeenBy: (myWonderland getScene) undoable: false.
							].
				].
