randomShortPoint
	^(((random next * 65536) @ (random next * 65536)) - (32768 @ 32768)) truncated