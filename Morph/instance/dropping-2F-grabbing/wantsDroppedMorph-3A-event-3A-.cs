wantsDroppedMorph: aMorph event: evt
	"Return true if the receiver wishes to accept the given morph, which is being dropped into the world by a hand in response to the given event. This default implementation returns false."

	^ (self valueOfProperty: #openToDragAndDrop) == true
