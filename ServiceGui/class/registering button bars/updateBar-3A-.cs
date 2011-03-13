updateBar: cat
	| newBar |
	self bars 
		select: [:assoc | (assoc key id = cat id) & assoc value notNil] 
		thenDo: [:assoc | 
			cat requestor: assoc key requestor.
			newBar := self new buttonBarFor: cat.
			assoc value removeAllMorphs.
			newBar submorphsDo: [:m | assoc value addMorphBack: m]]