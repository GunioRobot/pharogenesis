newWithMovieNoSound: aFileName
	| primary |

	primary _ self buildMorphics: aFileName.
	primary playVideoStream: 0.
	^primary

