value: aNumber

	| val |
	value _ aNumber.
	val _ value.
	submorphs reverseDo:
		[:m |
		m digit: val \\ 10.
		val _ val // 10].
	self changed.