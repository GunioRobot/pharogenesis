transformFrom: uberMorph
	"Return a transform to be used to map coordinates in a morph above me into my local coordinates, or vice-versa. This is used to support scrolling, scaling, and/or rotation. This default implementation just returns my owner's transform or the identity transform if my owner is nil."

	owner == uberMorph ifTrue: [^ MorphicTransform identity].
	owner ifNil: [^ MorphicTransform identity].
	^ owner transformFrom: uberMorph
