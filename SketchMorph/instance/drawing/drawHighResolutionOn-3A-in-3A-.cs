drawHighResolutionOn: aCanvas in: aRectangle

	| r finalClipRect scale sourceOrigin sourceExtent sourceRect biggerSource biggerDestExtent interForm offsetInBigger |

	r _ aRectangle translateBy: aCanvas origin.
	finalClipRect _ r intersect: (aCanvas clipRect translateBy: aCanvas origin).
	self canBeEnlargedWithB3D ifTrue: [
		(WarpBlt toForm: aCanvas form)
			clipRect: finalClipRect;
			sourceForm: originalForm;
			cellSize: 2;  "installs a colormap"
			combinationRule: Form paint;

			copyQuad: originalForm boundingBox innerCorners 
			toRect: r.
		^self
	].
	scale _ aRectangle extent / originalForm extent.
	sourceOrigin _ originalForm offset + (aCanvas clipRect origin - aRectangle origin / scale).
	sourceExtent _ aCanvas clipRect extent / scale.
	sourceRect _ sourceOrigin rounded extent: sourceExtent rounded.
	biggerSource _ sourceRect expandBy: 1.
	biggerDestExtent _ (biggerSource extent * scale) rounded.
	offsetInBigger _ (sourceOrigin - biggerSource origin * scale) rounded.

	interForm _ Form extent: biggerDestExtent depth: aCanvas depth.
	(originalForm copy: biggerSource)
		displayInterpolatedIn: interForm boundingBox
		on: interForm.
	aCanvas 
		drawImage: interForm 
		at: aCanvas clipRect origin 
		sourceRect: (offsetInBigger extent: aCanvas clipRect extent).


