makeMovie
	"Take all the currently selected frames and make a new movie out of it"
	| firstSelection lastSelection |
	firstSelection _  submorphs size + 1.
	lastSelection _ 0.
	submorphs doWithIndex:[:m :index|
		m isSelected ifTrue:[
			firstSelection _ firstSelection min: index.
			lastSelection _ lastSelection max: index.
		].
	].
	firstSelection > lastSelection
		ifTrue:[^self inform:'You have to select the frames first'].
	(player copyMovieFrom: firstSelection to: lastSelection) open