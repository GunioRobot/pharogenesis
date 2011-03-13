newWithMovieNoSound: aFileName
	| primary |

	primary := self buildMorphics: aFileName.
	primary playVideoStream: 0.
	^primary

