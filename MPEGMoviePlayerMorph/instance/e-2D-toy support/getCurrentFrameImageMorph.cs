getCurrentFrameImageMorph
	"Answer an ImageMorph containing the current frame scaled to the size of my display."

	^ ImageMorph new image: (moviePlayer currentFrameScaled)
