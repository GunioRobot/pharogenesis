refresh
	"This is a one-time only method for bootstraping the new registry. Here we will scan all classes for #windowColorSpecification methods and register those to the registry"

	((self systemNavigation allClassesImplementing: #windowColorSpecification)
		collect: [:aClass | aClass theNonMetaClass windowColorSpecification])
		do: [:spec | self registerColorSpecification: spec toClassNamed: spec classSymbol ].