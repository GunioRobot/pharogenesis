insert: anObject before: spot

  "  spot is an index in the range firstIndex .. lastIndex, such an index is not known from outside the collection. 
     Never use this method in your code, it is meant for private use by OrderedCollection only.
     The methods for use are:
        #add:before:   to insert an object before another object
        #add:beforeIndex:   to insert an object before a given position. "
	| "index" delta spotIndex|
	spotIndex _ spot.
	delta _ spotIndex - firstIndex.
	firstIndex = 1
		ifTrue: 
			[self makeRoomAtFirst.
			spotIndex _ firstIndex + delta].
	firstIndex _ firstIndex - 1.
	array
		replaceFrom: firstIndex
		to: spotIndex - 2
		with: array
		startingAt: firstIndex + 1.
	array at: spotIndex - 1 put: anObject.
"	index _ firstIndex _ firstIndex - 1.
	[index < (spotIndex - 1)]
		whileTrue: 
			[array at: index put: (array at: index + 1).
			index _ index + 1].
	array at: index put: anObject."
	^ anObject