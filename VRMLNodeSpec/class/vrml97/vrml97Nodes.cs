vrml97Nodes
	"VRMLNodeSpec initialize"
	| stream |
	stream := VRMLStream on: (ReadStream on: self vrml97NodeDefinition).
	^VRMLNodeParser new parseDefinitions: stream