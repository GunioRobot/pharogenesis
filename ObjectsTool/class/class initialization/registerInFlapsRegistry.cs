registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(ObjectsTool			newStandAlone				'Object Catalog'		'A tool that lets you browse the catalog of objects')
						forFlapNamed: 'PlugIn Supplies'.
						cl registerQuad: #(ObjectsTool		newStandAlone				'Object Catalog'		'A tool that lets you browse the catalog of objects')
						forFlapNamed: 'Widgets'.]