jumpFor: team from: loc havingVisited: dict
	"Recursively explore all jumps from loc, leaving in dict
	the prior position from which we got there"

	"Fasten seatbelts..."
	((((sixDeltas
		collect: [:d | loc + d])
		select: [:p | (self at: p) notNil and: [(self at: p) > 0]])
		collect: [:p | p + (p - loc)])
		select: [:p | (self at: p) notNil and: [(self at: p) = 0]])
		do: [:p | (dict includesKey: p) ifFalse:
			[dict at: p put: ((dict at: loc) copyWith: p).
			self jumpFor: team from: p havingVisited: dict]]