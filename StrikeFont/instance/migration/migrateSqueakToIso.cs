migrateSqueakToIso
	| map |
	map _ characterToGlyphMap.
	map ifNil:[^self "Don't know how to migrate"].
	(self name beginsWith: 'NewYork')
		ifTrue:[
			128 to: 255 do:[:ascii |
				map at: ascii + 1 put: ascii]].
	((self name beginsWith: 'Comic') or:[self name beginsWith: 'Atlanta'] )
		ifTrue:[
			128 to: 255 do:[:ascii |
				map at: ascii + 1 put: (Character value: ascii) isoToSqueak asciiValue]].