reducedPaletteOfSize: nColors
	"Return an array of colors of size nColors, such that those colors
	represent well the pixel values actually found in this form."
	| threshold tallies colorTallies dist delta palette cts top cluster |
	tallies _ self tallyPixelValues.  "An array of tallies for each pixel value"
	threshold _ width * height // 500.

	"Make an array of (color -> tally) for all tallies over threshold"
	colorTallies _ Array streamContents:
		[:s | tallies withIndexDo:
			[:v :i | v >= threshold ifTrue:
				[s nextPut: (Color colorFromPixelValue: i-1 depth: depth) -> v]]].

	"Extract a set of clusters by picking the top tally, and then removing all others
	whose color is within dist of it.  Iterate the process, adjusting dist until we get nColors."
	dist _ 0.2.  delta _ dist / 2.
		[cts _ colorTallies copy.
		palette _ Array streamContents: [:s |
			[cts isEmpty] whileFalse:
				[top _ cts detectMax: [:a | a value].
				cluster _ cts select: [:a | (a key diff: top key) < dist].
				s nextPut: top key -> (cluster detectSum: [:a | a value]).
				cts _ cts copyWithoutAll: cluster]].
		palette size = nColors or: [delta < 0.001]]
		whileFalse:
			[palette size > nColors
				ifTrue: [dist _ dist + delta]
				ifFalse: [dist _ dist - delta].
			delta _ delta / 2].
	^ palette collect: [:a | a key]
