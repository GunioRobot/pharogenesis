widen: char by: delta 
	| newForm |
	^ self 
		alter: char
		formBlock: 
			[ :charForm | 
			"Make a new form, wider or narrower..."
			newForm := Form extent: charForm extent + (delta @ 0).
			charForm displayOn: newForm.	"Copy this image into it"
			newForm	"and substitute it in the font" ]