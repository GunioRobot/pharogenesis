convertToReferenceMorph
	| aMorph |
	aMorph _ ReferenceMorph new referent: morphToInstall.
	aMorph position: self position.
	self become: aMorph.