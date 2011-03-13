deriveHScrollRange

	|  unadjustedRange totalRange |
	(list isNil or: [list isEmpty]) 
		ifTrue:[hScrollRangeCache _ Array with: 0 with: 0 with: 0 with: 0 with: 0 ]
		ifFalse:[ 
			unadjustedRange _ self listMorph hUnadjustedScrollRange.
			totalRange _ unadjustedRange + self hExtraScrollRange + self hMargin.
			hScrollRangeCache _ Array 
										with: totalRange 
										with: unadjustedRange 
										with: list size 
										with: list first 
										with: list last .
		].
