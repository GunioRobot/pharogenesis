asB3DSimpleMesh
	| facets rightEyelets leftEyelets bounds triangle rightLeg end |
	bounds _ self polygon bounds.
	self elevateSpine.
	facets _ OrderedCollection new.

	end _ triangle _ self triangulation faces keys anyOne.
	leftEyelets _ self eyeletsFor: triangle leftLeg in: bounds extent.

	[
		rightLeg _ triangle rightLeg.
		rightEyelets _ self eyeletsFor: rightLeg in: bounds extent.
		self tie: leftEyelets with: rightEyelets to: facets.
		
		leftEyelets _ rightEyelets.
		triangle _ rightLeg opposite face.
		triangle = end] whileFalse.

	self addOtherHemisphereTo: facets.

	^ (B3DSimpleMesh withAll: facets) asIndexedMesh