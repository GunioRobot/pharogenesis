acceptDroppingMorph: aMorph event: evt
	"This message is sent when a morph is dropped onto a morph that has agreed to accept the dropped morph by responding 'true' to the wantsDroppedMorph:Event: message. This default implementation just adds the given morph to the receiver."

	self addMorph: aMorph.
