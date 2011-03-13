methodHolders
	| all |
	"search for all scripts that are in MethodHolders.  These are the ones that have versions."

	all _ IdentitySet new.
	self allMorphsAndBookPagesInto: all.
	all _ all select: [:mm | mm class = MethodMorph].
	MethodHolders _ all asArray collect: [:mm | mm model].

