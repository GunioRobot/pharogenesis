initialize

	state _ CompoundTextConverterState 
		g0Size: 1 g1Size: 1 g0Leading: 0 g1Leading: 0 charSize: 1 streamPosition: 0.
	acceptingEncodings _ #(ascii iso88591 jisx0208 gb2312 ksc5601 ksx1001 ) copy.
