doTransform: node
	| attr c r s sr t xform oldActor |
	attr _ node attributeValueNamed: 'center'.
	attr notNil ifTrue:[c _ self positionFrom: attr].
	attr _ node attributeValueNamed: 'rotation'.
	attr notNil ifTrue:[r _ self rotationFrom: attr].
	attr _ node attributeValueNamed: 'scale'.
	attr notNil ifTrue:[s _ self scaleFrom: attr].
	attr _ node attributeValueNamed: 'scaleOrientation'.
	attr notNil ifTrue:[sr _ self rotationFrom: attr].
	attr _ node attributeValueNamed: 'translation'.
	attr notNil ifTrue:[t _ self positionFrom: attr].
	xform _ B3DMatrix4x4 identity.
	xform translation: t+c.
	xform _ xform composedWithLocal: r asMatrix4x4.
	xform _ xform composedWithLocal: sr asMatrix4x4.
	xform _ xform composedWithLocal: (B3DMatrix4x4 identity scaling: s).
	xform _ xform composedWithLocal: sr negated asMatrix4x4.
	xform _ xform composedWithLocal: (B3DMatrix4x4 identity translation: c negated).
	oldActor _ currentActor.
	currentActor _ self createActorFor: nil.
	currentActor setComposite: xform.
	super doTransform: node.
	currentActor _ oldActor.