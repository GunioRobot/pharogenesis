unhighlight

	(self isBlank or: [self color = self normalColor])
		ifFalse: [self color: self normalColor]