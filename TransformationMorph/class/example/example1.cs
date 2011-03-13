example1
	| stringMorph transformationMorph |
	stringMorph _ 'vertical text' asMorph.
	transformationMorph _ TransformationMorph new asFlexOf: stringMorph.
	transformationMorph angle: Float pi / 2.
	transformationMorph position: 5@5.
	transformationMorph openInWorld.