collectSplitVertices: aSet
	"Collect the non smooth vertices into a Dictionary
		vertex index -> Dictionary
							smoothing group -> list of face indexes.
	"
	| face flag vtxIndex groups groupDict |
	groupDict _ Dictionary new: aSet size * 2.
	1 to: faces size do:[:faceIndex|
		face _ faces at: faceIndex.
		flag _ smoothFlags at: faceIndex.
		1 to: 3 do:[:j|
			vtxIndex _ face at: j.
			(aSet includes: vtxIndex) ifTrue:[ 
				groups _ groupDict at: vtxIndex ifAbsentPut:[Dictionary new].
				(groups at: flag ifAbsentPut:[OrderedCollection new]) add: faceIndex.
			].
		].
	].
	^groupDict