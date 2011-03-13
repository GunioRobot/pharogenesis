initialize
	super initialize.
	backgroundForm _ (
		(StringMorph contents: '......' font: (TextStyle default fontOfSize: 24))
			color: Color white
	) imageForm.
	bounds _ backgroundForm boundingBox.
