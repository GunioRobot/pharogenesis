acceptDroppingMorph: aMorph event: evt
	"This message is sent when a morph is dropped onto a morph that has agreed to accept the dropped morph by responding 'true' to the wantsDroppedMorph:Event: message. This default implementation just adds the given morph to the receiver."
	| actor |
	actor _ myCamera pickAt: evt cursorPoint.
	actor == nil ifTrue:[^self addMorphFront: aMorph]. "This should never happen."
	myWonderland getUndoStack push: (UndoTextureChange for: actor from: actor getTexturePointer).
	aMorph installAsWonderlandTextureOn: actor.
	self world abandonAllHalos.
	"AAAARRRRGGGGGHHHH!!!!"
	aMorph owner ifNotNil:[aMorph owner privateRemoveMorph: aMorph].
	aMorph privateOwner: self.
	"Note: The above makes aMorph invisible to stupid HandMorph but keeps it in the world so it can continue stepping"
	actor adjustToTextureIfNecessary.