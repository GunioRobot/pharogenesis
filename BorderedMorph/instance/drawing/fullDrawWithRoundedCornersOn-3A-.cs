fullDrawWithRoundedCornersOn: aCanvas
	CornerRounder roundCornersOf: self on: aCanvas
		displayBlock: [super fullDrawOn: aCanvas]
		borderWidth: borderWidth