newWithMovie: aFileName
	| primary |

	primary _ self buildMorphics: aFileName.
	primary playStream: 0.
	^primary

