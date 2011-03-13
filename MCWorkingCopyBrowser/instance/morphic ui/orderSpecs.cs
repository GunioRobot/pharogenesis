orderSpecs
	^ {
		'sort alphabetically' -> [ :a :b | a package name <= b package name ].
		'sort dirty first' -> [ :a :b | 
			a needsSaving = b needsSaving
				ifTrue: [ a package name <= b package name ]
				ifFalse: [ a needsSaving ] ].
		'sort dirty last' -> [ :a :b | 
			a needsSaving = b needsSaving
				ifTrue: [ a package name <= b package name ]
				ifFalse: [ b needsSaving ] ].
		'only dirty' -> [ :a :b | a package name <= b package name ]
	}