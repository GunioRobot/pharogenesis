add: edge beforeIndex: index
	tally = array size ifTrue:[self grow].
	tally+1 to: index+1 by: -1 do:[:i|array at: i put: (array at:i-1)].
	"array replaceFrom: index+1 to: tally+1 with: array startingAt: index."
	array at: index put: edge.
	tally _ tally + 1