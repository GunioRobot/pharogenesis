copyMovieFrom: firstFrame to: lastFrame
	"Note: This is different if sent to a sprite since a sprite contains a *full* animation
	and is therefore always completely."
	^super copyMovieFrom: 1 to: maxFrames.