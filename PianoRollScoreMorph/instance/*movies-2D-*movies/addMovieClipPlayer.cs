addMovieClipPlayer

	movieClipPlayer := MoviePlayerMorph new.
	movieClipPlayer pianoRoll: self.  "back link"
	self activeHand attachMorph: movieClipPlayer