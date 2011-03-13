blue
	"Find the average blue of this pattern.  6/20/96 tk"

	| sum |
	sum _ 0.
	colorArray2D do: [:each | sum _ sum + each blue].
	^ sum / (colorArray2D width * colorArray2D height)