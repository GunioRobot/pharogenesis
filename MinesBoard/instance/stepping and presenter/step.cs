step

	flashCount = 0 ifFalse: [
		self submorphsDo:
			[:m |
				m color: m color negated.].
			flashCount _ flashCount - 1.
			].
