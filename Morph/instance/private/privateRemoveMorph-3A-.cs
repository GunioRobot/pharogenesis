privateRemoveMorph: aMorph
	"Private! Should only be used by methods that maintain the ower/submorph invariant."

	aMorph changed.
	submorphs _ submorphs copyWithout: aMorph.
	self layoutChanged.
