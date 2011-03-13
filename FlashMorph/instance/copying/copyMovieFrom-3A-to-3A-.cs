copyMovieFrom: firstFrame to: lastFrame
	| copy |
	copy := self copy.
	copy copyExtension.
	copy addAllMorphs: 
		(self submorphs collect:[:m| m copyMovieFrom: firstFrame to: lastFrame]).
	^copy