duplicateMorph

	| new oldModel |
	new _ argument fullCopy.
	oldModel _ argument findA: MorphicModel.
	oldModel ifNotNil: [
		oldModel model duplicate: (new findA: MorphicModel) from: oldModel].
	self grabMorphFromMenu: new.
