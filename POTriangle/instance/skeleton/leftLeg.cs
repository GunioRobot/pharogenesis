leftLeg
	"If one edge of the triangle is tagged as #border or #spine then return   
	 the edge that is before the border edge or after the spine edge."
	| bidx sidx |
	bidx _ sidx _ 0.
	1 to: self edges size do: 
		[:idx | 
		((self edges at: idx)
			testTag: #border)
			ifTrue: [bidx _ idx].
		((self edges at: idx)
			testTag: #spine)
			ifTrue: [sidx _ idx]].
	bidx > 0 ifTrue: [^ self edges atWrap: bidx + 1].
	^ self edges atWrap: sidx - 1