initForEvents
	eventSubscribers _ Set new.
	mouseDownMorph _ nil.
	lastEvent _ MorphicEvent new.
	eventTransform _ MorphicTransform identity.
	self resetClickState.
	mouseOverTimes _ Dictionary new.
	suppressDrawing _ false
