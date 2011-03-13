duplicateMorph

	| newMorph |
	newMorph _ argument usableDuplicate.
	self grabMorphFromMenu: newMorph.
	newMorph costumee ifNotNil: [newMorph costumee startRunning].


	" -- End of presently active code -- "

	self flag: #noteToDan.  "The following code was formerly in duplicateMorph, and may need to be reincorporated somewhere:

	oldModel _ argument findA: MorphicModel.
	oldModel ifNotNil:
		[oldModel model duplicate: (new findA: MorphicModel) from: oldModel]."

	self flag: #noteToTed.  "the following corrsponds to the hook you had in for getting script tiles straightened out:

	newMorph justDuplicatedFrom: argument.
		We depend on nameInModel working, and hand having grabbed already (old tck note)"
