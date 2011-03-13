depth: d
	"Set the depth.  6/22/96 tk"

	(d = 16) | (d = 32) ifFalse: [
		^ self error: 'Use an Array for other depths'].
	depth _ d