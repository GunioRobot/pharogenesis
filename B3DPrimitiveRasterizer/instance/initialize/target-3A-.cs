target: aForm
	| bb span sourceForm |
	super target: aForm.
	target ifNil:[^self].
	"Note: span must be Bitmap since software rasterizer expects canonical RGBA for now"
	span _ Bitmap new: 2048.
	sourceForm _ Form extent: span size@1 depth: 32 bits: span.
	bb _ BitBlt current toForm: target.
	self class primitiveSetBitBltPlugin: bb getPluginName.
	bb sourceForm: sourceForm.
	bb isFXBlt ifTrue:[
		"Specific setup for FXBlt is necessary"
		bb colorMap: (sourceForm colormapIfNeededFor: target).
		bb combinationRule: (target depth >= 8 ifTrue:[34] ifFalse:[Form paint]).
	] ifFalse:[
		bb colorMap: (sourceForm colormapIfNeededForDepth: target depth).
		bb combinationRule: (target depth >= 8 ifTrue:[34] ifFalse:[Form paint]).
	].
	bb destX: 0; destY: 0; sourceX: 0; sourceY: 0; width: 1; height: 1.
	state spanBuffer: span.
	state bitBlt: bb.