closeAccountEditor
	accountEditor ifNil: [ ^self ].
	accountEditor window delete.
	accountEditor _ nil.