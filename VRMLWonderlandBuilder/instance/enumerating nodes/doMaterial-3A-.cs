doMaterial: node
	| ambientIntensity diffuseColor emissiveColor shininess specularColor material |
	ambientIntensity _ (node attributeValueNamed: 'ambientIntensity').
	diffuseColor _ (node attributeValueNamed: 'diffuseColor').
	emissiveColor _ (node attributeValueNamed:'emissiveColor').
	shininess _ (node attributeValueNamed: 'shininess').
	specularColor _ (node attributeValueNamed: 'specularColor').
	"transparency _ (node attributeValueNamed:'transparency')."
	material _ B3DMaterial new.
	material ambientPart: (diffuseColor * ambientIntensity).
	material diffusePart: diffuseColor.
	material specularPart: specularColor.
	material emission: emissiveColor.
	material shininess: shininess.
	attributes at: #currentMaterial put: material.