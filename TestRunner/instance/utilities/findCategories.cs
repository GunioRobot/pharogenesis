findCategories
	| visible |
	visible := Set new.
	self baseClass withAllSubclassesDo: [ :each |
		each category ifNotNilDo: [ :category |
			visible add: category ] ].
	^ Array streamContents: [ :stream |
		Smalltalk organization categories do: [ :each |
			(visible includes: each)
				ifTrue: [ stream nextPut: each ] ] ].