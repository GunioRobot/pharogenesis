green
	"Find the average green of this pattern.  6/20/96 tk"

	| sum |
	sum _ 0.
	colorArray2D do: [:each | sum _ sum + each green].
	^ sum / (colorArray2D width * colorArray2D height)