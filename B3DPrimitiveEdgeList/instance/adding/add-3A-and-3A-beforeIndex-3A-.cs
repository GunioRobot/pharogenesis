add: edge1 and: edge2 beforeIndex: index
	tally+1 >= array size ifTrue:[self grow].
	tally+2 to: index+2 by: -1 do:[:i|array at: i put: (array at:i-2)].
	"array replaceFrom: index+2 to: tally+2 with: array startingAt: index."
	array at: index put: edge1.
	array at: index+1 put: edge2.
	tally _ tally + 2.