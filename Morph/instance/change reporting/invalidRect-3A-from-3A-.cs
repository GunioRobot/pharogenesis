invalidRect: aRectangle from: aMorph
	| damageRect |
	aRectangle hasPositiveExtent ifFalse: [ ^self ].
	damageRect _ aRectangle.
	aMorph == self ifFalse:[
		"Clip to receiver's clipping bounds if the damage came from a child"
		self clipSubmorphs 
			ifTrue:[damageRect _ aRectangle intersect: self clippingBounds]].
	owner ifNotNil: [owner invalidRect: damageRect from: self].
	self wonderlandTexture ifNotNil:[self isValidWonderlandTexture: false].
