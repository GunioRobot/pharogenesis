do: aBlock displayingProgress: aString
	aString
		displayProgressAt: Sensor cursorPoint
		from: 0 to: self size
		during:
			[:bar |
			self withIndexDo:
				[:each :i |
				bar value: i.
				aBlock value: each]]