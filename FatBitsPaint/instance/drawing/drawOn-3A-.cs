drawOn: aCanvas
	| f |
	f _ self rotatedForm.
	backgroundColor ifNotNil: [aCanvas fillRectangle: bounds fillStyle: backgroundColor].
	aCanvas translucentImage: f at: bounds origin.