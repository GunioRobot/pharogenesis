renderOn: aRenderer
	"Draw the actor."

	"Save the old transformation matrix"
	aRenderer pushMatrix.

	"Modify the matrix using our composite matrix for position and orientation"
	aRenderer transformBy: compositeMatrix.

	"Save the new transformation matrix"
	aRenderer pushMatrix.

	"Modify the matrix using our scale matrix - we do this seperately to avoid scaling space"
	aRenderer transformBy: scaleMatrix.

	"Draw our mesh if the object is not hidden"
	(isHidden) ifFalse: [ self drawMesh: aRenderer ].

	"Remove the scaling matrix"
	aRenderer popMatrix.

	"Draw our children.
	Note: For correct picking it is important to use B3DRenderEngine>>render: here."
	myChildren do: [:child | aRenderer render: child].

	"Restore the old transformation matrix"
	aRenderer popMatrix.