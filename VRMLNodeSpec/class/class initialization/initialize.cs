initialize
	"VRMLNodeSpec initialize"
	VRMLStream initialize.
	VRMLNodeParser initialize.
	CurrentSpecs := self vrml97Nodes.
	UndefinedSpec := VRMLNodeSpec name:'Undefined' attributes: #().
	CurrentSpecs doWithIndex:[:nodeSpec :index|
		nodeSpec nodeId: index.
	].