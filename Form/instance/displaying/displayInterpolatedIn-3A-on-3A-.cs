displayInterpolatedIn: aRectangle on: aForm
	"Display the receiver on aForm, using interpolation if necessary.
		Form fromUser displayInterpolatedOn: Display.
	Note: When scaling we attempt to use bilinear interpolation based
	on the 3D engine. If the engine is not there then we use WarpBlt.
	"
	| engine adjustedR |
	self extent = aRectangle extent ifTrue:[^self displayOn: aForm at: aRectangle origin].
	Smalltalk at: #B3DRenderEngine 
		ifPresent:[:engineClass| engine _ (engineClass defaultForPlatformOn: aForm)].
	engine ifNil:[
		"We've got no bilinear interpolation. Use WarpBlt instead"
		(WarpBlt current toForm: aForm)
			sourceForm: self destRect: aRectangle;
			combinationRule: 3;
			cellSize: 2;
			warpBits.
		^self
	].

	"Otherwise use the 3D engine for our purposes"

	"there seems to be a slight bug in B3D which the following adjusts for"
	adjustedR _ (aRectangle withRight: aRectangle right + 1) translateBy: 0@1.
	engine viewport: adjustedR.
	engine material: (B3DMaterial new emission: Color white).
	engine texture: self.
	engine render: (B3DIndexedQuadMesh new plainTextureRect).
	engine finish.