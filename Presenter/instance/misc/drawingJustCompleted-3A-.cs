drawingJustCompleted: aSketchMorph
	| aPaintBox aPaintTab aWorld |
	(aPaintTab _ (aWorld _ associatedMorph world) paintingFlapTab)
		ifNotNil:
			[aPaintTab hideFlap]
		ifNil:
			[(aPaintBox _ aWorld paintBox) ifNotNil:
				[aPaintBox delete]].

	(aWorld hasProperty: #automaticFlapViewing)
		ifTrue:
			[^ aWorld presenter viewMorph: aSketchMorph].

	(aSketchMorph pasteUpMorph hasProperty: #automaticViewing)
		ifTrue:
			[self viewMorph: aSketchMorph]