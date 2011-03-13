addPatchVarNamed: nameSymbol

	| f |
	f _ KedamaPatchMorph newExtent: self costume dimensions.
	f assuredPlayer assureUniClass.
	f setNameTo: (ActiveWorld unusedMorphNameLike: f innocuousName).
	self addInstanceVariable2Named: nameSymbol type: #Patch value: f player.
	^ f.
