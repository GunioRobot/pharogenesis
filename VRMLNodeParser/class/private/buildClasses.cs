buildClasses
	"VRMLNodeParser buildClasses"
	Utilities informUserDuring:[:bar|
	VRMLNodeSpec currentSpecs do:[:nodeSpec|
		bar value: 'Compiling ', nodeSpec name.
		(nodeSpec attributeNamed: 'children') notNil ifTrue:[
			self compileCompositeNode: nodeSpec.
		] ifFalse:[
		('*Light*' match: nodeSpec name ) ifTrue:[
			self compileLightNode: nodeSpec.
		] ifFalse:[
		('*Interpolator*' match: nodeSpec name) ifTrue:[
			self compileInterpolatorNode: nodeSpec.
		] ifFalse:[
		('*Sensor*' match: nodeSpec name) ifTrue:[
			self compileSensorNode: nodeSpec.
		] ifFalse:[
			self compileSimpleNode: nodeSpec.
		]]]]].
	].