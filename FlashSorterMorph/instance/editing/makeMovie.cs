makeMovie
	"Take all the currently selected frames and make a new movie out of it"
	| firstSelection lastSelection |
	firstSelection :=  submorphs size + 1.
	lastSelection := 0.
	submorphs doWithIndex:[:m :index|
		m isSelected ifTrue:[
			firstSelection := firstSelection min: index.
			lastSelection := lastSelection max: index.
		].
	].
	firstSelection > lastSelection
		ifTrue:[^self inform:'You have to select the frames first'].
	(player copyMovieFrom: firstSelection to: lastSelection) open