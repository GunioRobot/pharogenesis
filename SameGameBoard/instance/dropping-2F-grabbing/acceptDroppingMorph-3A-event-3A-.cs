acceptDroppingMorph: aMorph event: evt
	"Allow the user to set the protoTile just by dropping it on this morph."

	self protoTile: aMorph.
	self removeAllMorphs.
