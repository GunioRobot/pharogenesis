convertEvent: evt
	"Create a Wonderland event that will be dispatched later on from the given MorphicEvent."
	| newEvent temp clickedActor clickedVertex |
	eventFocus 
		ifNil:[ "Find the clicked actor under the cursor"
			temp _ myCamera pickObjectAndVertexAt: evt cursorPoint.
			clickedActor _ temp key.
			clickedVertex _ temp value]
		ifNotNil: [ "Route all events to the object having the focus"
			clickedActor _ eventFocus.
			clickedVertex _ nil].
	clickedActor ifNotNil:[
		newEvent _ WonderlandEvent new.
		newEvent setMorphicEvent: evt.
		newEvent setCameraMorph: self.
		newEvent setActor: clickedActor.
		newEvent setCamera: myCamera.
		newEvent setCursorDelta: ((evt cursorPoint) - lastCursorPoint).
		newEvent setCursorPoint: (lastCursorPoint _ evt cursorPoint).
		newEvent setVertex: clickedVertex.
		evt isKeystroke ifTrue:[newEvent setKey: (evt keyCharacter)].
	].
	^newEvent