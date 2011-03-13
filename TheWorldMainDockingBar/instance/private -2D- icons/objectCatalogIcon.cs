objectCatalogIcon
	^ Preferences tinyDisplay
		ifTrue: [MenuIcons smallObjectCatalogIcon]
		ifFalse: [MenuIcons objectCatalogIcon]