fullDrawOn: aCanvas
	Preferences roundedWindowCorners
		ifTrue: [CornerRounder roundCornersOf: self on: aCanvas
					displayBlock:
						[aCanvas drawMorph: self.
						self basicFullDrawOn: aCanvas]
					borderWidth: 2]
		ifFalse: [super fullDrawOn: aCanvas]