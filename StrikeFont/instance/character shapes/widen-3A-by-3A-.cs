widen: char by: delta
	| newForm |
	^ self alter: char formBlock:  "Make a new form, wider or narrower..."
		[:charForm | newForm _ Form extent: charForm extent + (delta@0).
		charForm displayOn: newForm.  "Copy this image into it"
		newForm]    "and substitute it in the font"