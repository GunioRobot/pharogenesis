fullDrawOn: aCanvas

	(Preferences roundedWindowCorners and: [(owner isKindOf: SystemWindow) not])
		ifTrue: [CornerRounder roundCornersOf: self on: aCanvas
					displayBlock: [super fullDrawOn: aCanvas]
					borderWidth: 1]
		ifFalse: [super fullDrawOn: aCanvas]