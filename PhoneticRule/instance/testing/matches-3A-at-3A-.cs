matches: aString at: anInteger
	^ (self textMatches: aString at: anInteger)
		and: [(self leftMatches: aString at: anInteger)
			and: [self rightMatches: aString at: anInteger]]