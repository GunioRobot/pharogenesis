fullDrawOn: aCanvas
	"Overridden to clip submorph drawing to my bounds,
	and to translate, rotate and scale as appropriate."
	| clippingCanvas sourceQuad imageForm imageQuad warp innerRect |
	(aCanvas isVisible: self bounds) ifFalse: [^ self].
	self drawOn: aCanvas.
	transform isPureTranslation
		ifTrue:
		[clippingCanvas _ aCanvas copyOffset: transform offset negated
									clipRect: self innerBounds.
		submorphs reverseDo: [:m | m fullDrawOn: clippingCanvas]]
		ifFalse:
		[innerRect _ self innerBounds.
		sourceQuad _ transform sourceQuadFor: innerRect.
		submorphs reverseDo:
			[:m | imageForm _ m imageForm.
			imageQuad _ sourceQuad collect: [:p | p - imageForm offset].
			warp _ aCanvas warpFrom: imageQuad toRect: innerRect.
			warp cellSize: smoothing;  "installs a colormap if smoothing > 1"
				sourceForm: imageForm;
				warpBits]]
	