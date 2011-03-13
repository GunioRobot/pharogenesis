drawingJustCompleted: aSketchMorph
	"The user just finished drawing.  Now maybe put up a viewer"

	| aWorld |

	aWorld := associatedMorph world.
	(aWorld hasProperty: #automaticFlapViewing)
		ifTrue:
			[^ aWorld presenter viewMorph: aSketchMorph].
