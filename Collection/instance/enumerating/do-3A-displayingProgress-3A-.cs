do: aBlock displayingProgress: aString

	aString
		displayProgressAt: Sensor cursorPoint
		from: 0 to: self size
		during:
			[:bar |
			self inject: 1 into:
				[:index :each |
				bar value: index.
				aBlock value: each.
				index + 1]]