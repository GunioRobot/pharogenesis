privateRemoveMorph: aMorph
	"Private! Should only be used by methods that maintain the ower/submorph invariant."

	self isInWorld ifTrue:[self invalidRect: aMorph fullBounds from: aMorph].
	submorphs _ submorphs copyWithout: aMorph.
	self layoutChanged.
