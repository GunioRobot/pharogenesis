indicateModalChildForMorph: aMorph
	"Flash the button corresonding to the given morph ."
	
	(self buttonForMorph: aMorph) ifNotNilDo: [:b |
		b indicateModalChild]