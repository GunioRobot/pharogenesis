randomTransitionSelector
	"Return a two-argument transition selector, chosen randomly.  7/25/96 sw"

	^ #(fadeImageCoarse:at: fadeImageFine:at: fadeImageHor:at: fadeImageHorFine:at: fadeImageSquares:at: fadeImageVert:at: zoomInTo:at: zoomOutTo:at:) atRandom

" slideImage:at:delta: wipeImage:at:delta: "