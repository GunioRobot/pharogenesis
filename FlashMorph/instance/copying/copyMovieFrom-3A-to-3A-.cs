copyMovieFrom: firstFrame to: lastFrame
	| copy |
	copy _ self copy.
	copy copyExtension.
	copy addAllMorphs: 
		(self submorphs collect:[:m| m copyMovieFrom: firstFrame to: lastFrame]).
	^copy