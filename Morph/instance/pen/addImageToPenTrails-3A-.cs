addImageToPenTrails: aForm 
	owner
		ifNil: [^ self].
	owner addImageToPenTrails: aForm