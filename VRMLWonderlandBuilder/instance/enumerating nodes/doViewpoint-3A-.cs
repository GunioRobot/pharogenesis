doViewpoint: node
	| attr pos r fov name m camera |
	attr _ node attributeValueNamed: 'position'.
	attr notNil ifTrue:[pos _ self positionFrom: attr].
	attr _ node attributeValueNamed: 'orientation'.
	attr notNil ifTrue:[r _ self rotationFrom: attr].
	attr _ node attributeValueNamed: 'fieldOfView'.
	attr notNil ifTrue:[fov _ attr radiansToDegrees].
	attr _ node attributeValueNamed: 'description'.
	attr notNil ifTrue:[name _ attr].
	m _ B3DMatrix4x4 identity.
	m _ m composedWithGlobal: (r asMatrix4x4).
	m _ m composedWithGlobal: (B3DMatrix4x4 withOffset: pos).
	(currentActor == baseActor and:[defaultCamera ~~ nil]) ifTrue:[
		camera _ defaultCamera.
		defaultCamera _ nil.
	] ifFalse:[
		camera _ myWonderland makeCameraNamed: (name ifNil:['camera']) parent: currentActor.
	].
	camera setComposite: m.
	camera setFieldOfView: fov.