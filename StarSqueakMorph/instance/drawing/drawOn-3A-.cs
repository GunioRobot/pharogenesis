drawOn: aCanvas
	"Display this StarSqueak world."

	| tmpForm bitBlt t |
	"copy the patches form"
	tmpForm := patchForm deepCopy.

	"draw patchVariableToDisplay on top of tmpForm as translucent color"
	self displayPatchVariableOn: tmpForm color: Color yellow shift: logPatchVariableScale.

	"draw turtles on top of tmpForm"
	bitBlt := (BitBlt toForm: tmpForm)
		clipRect: tmpForm boundingBox;
		combinationRule: Form over.
	1 to: turtles size do: [:i |
		t := turtles at: i.
		bitBlt
			destX: (pixelsPerPatch * t x truncated)
			destY: (pixelsPerPatch * t y truncated)
			width: pixelsPerPatch
			height: pixelsPerPatch.
		bitBlt
			fillColor: t color;
			copyBits].

	"display tmpForm"
	aCanvas paintImage: tmpForm at: bounds origin.

