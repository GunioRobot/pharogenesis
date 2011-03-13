setMeshAnimationParameter: param
	myMesh == nil ifTrue:[^self].
	myMesh animationParameter: param