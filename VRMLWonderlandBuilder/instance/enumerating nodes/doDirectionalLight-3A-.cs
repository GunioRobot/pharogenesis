doDirectionalLight: node
	| ambientIntensity intensity color on material light dir |
	ambientIntensity _ (node attributeValueNamed:'ambientIntensity').
	intensity _ (node attributeValueNamed: 'intensity').
	color _ (node attributeValueNamed: 'color').
	dir _ self positionFrom: (node attributeValueNamed:'direction').
	on _ (node attributeValueNamed:'on').
	material _ B3DMaterialColor new.
	material ambientPart: (color * ambientIntensity).
	material diffusePart: (color * intensity).
	light _ myWonderland makeLight: (Wonderland wonderlandConstants at: 'directional').
	light lightColor: material.
	light setDirection: dir.
	currentActor ifNotNil:[light reparentTo: currentActor].