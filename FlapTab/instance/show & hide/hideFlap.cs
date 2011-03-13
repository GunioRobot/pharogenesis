hideFlap
	| aWorld |
	aWorld _ self world ifNil: [self currentWorld].
	referent privateDelete.
	aWorld removeAccommodationForFlap: self.
	flapShowing _ false.
	self isInWorld ifFalse: [aWorld addMorphFront: self].
	self adjustPositionAfterHidingFlap.
	aWorld haloMorphs do:
		[:m | m target isInWorld ifFalse: [m delete]]