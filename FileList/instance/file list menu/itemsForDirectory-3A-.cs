itemsForDirectory: dir 
	| services |
	services := OrderedCollection new.
	dir ifNotNil: [
		services
			addAll: (self class itemsForDirectory: dir).
		services last useLineAfter: true. ].
	services add: self serviceAddNewFile.
	services add: self serviceAddNewDirectory.
	^ services