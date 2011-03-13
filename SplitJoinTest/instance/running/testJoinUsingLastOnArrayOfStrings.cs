testJoinUsingLastOnArrayOfStrings
	self
		assert: (#('Squeak is modern' 'open source' 'highly portable' 'fast' 'full-featured' ) joinUsing: ', ' last: ' and ')
		equals: 'Squeak is modern, open source, highly portable, fast and full-featured'