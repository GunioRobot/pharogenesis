privateRemoveMorphWithAbsolutelyNoSideEffects: aMorph
	"Private! Should only be used by methods that maintain the ower/submorph invariant."
	"used to delete a morph from an inactive world"

	submorphs _ submorphs copyWithout: aMorph.

