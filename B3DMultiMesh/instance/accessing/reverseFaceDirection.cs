reverseFaceDirection
	| idSet |
	idSet := IdentitySet withAll:(self meshes collect:[:each| each faces]).
	idSet do:[:m| m reverseDirection].