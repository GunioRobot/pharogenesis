createPatchFormGetterAndSetter
	"Create BitBlt's for getting and setting patch colors."

	patchColorGetter _ BitBlt bitPeekerFromForm: patchForm.
	patchColorSetter _
		(BitBlt toForm: patchForm)
			combinationRule: Form over;
			clipRect: patchForm boundingBox;
			width: pixelsPerPatch;
			height: pixelsPerPatch.
