addMovieClipPlayer

	movieClipPlayer _ MoviePlayerMorph new.
	movieClipPlayer pianoRoll: self.  "back link"
	self activeHand attachMorph: movieClipPlayer