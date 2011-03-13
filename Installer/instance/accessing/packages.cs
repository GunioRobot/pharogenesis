packages
	
self sm ifTrue: [ ^self smPackages ].
self mc ifNotNil: [ ^self mcRepository allFileNames ].
self wsm ifNotNil: [ ^self wsmPackagesByName keys ].