borderColor: aColor
	(borderColor isColor and: [borderColor isTranslucentColor])
		== (aColor isColor and: [aColor isTranslucentColor])
		ifTrue: [super borderColor: aColor]
		ifFalse: ["Need to recompute fillForm and borderForm
					if translucency of border changes."
				super borderColor: aColor.
				self releaseCachedState]