vrml97Nodes
	"VRMLNodeParser vrml97Nodes"
	| stream |
	stream := VRMLStream on: (ReadStream on: self vrml97NodeDefinition).
	^VRMLNodeParser new parseDefinitions: stream