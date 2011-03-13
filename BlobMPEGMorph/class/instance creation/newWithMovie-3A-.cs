newWithMovie: aFileName
	| primary |

	primary := self buildMorphics: aFileName.
	primary playStream: 0.
	^primary

