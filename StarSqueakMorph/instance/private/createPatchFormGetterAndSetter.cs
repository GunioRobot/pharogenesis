createPatchFormGetterAndSetter
	"Create BitBlt's for getting and setting patch colors."

	patchColorGetter := BitBlt bitPeekerFromForm: patchForm.
	patchColorSetter :=
		(BitBlt toForm: patchForm)
			combinationRule: Form over;
			clipRect: patchForm boundingBox;
			width: pixelsPerPatch;
			height: pixelsPerPatch.
