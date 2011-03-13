versions
	
self sm ifTrue: [ ^self smVersions ].
self mc ifNotNil: [ ^self mcVersions ].
self wsm ifNotNil: [ ^self wsmVersions ].