ccg: cg generateCoerceToValueFrom: aNode on: aStream

	cg 
		generateCoerceToPtr: (self ccgDeclareCForVar: '')
		fromObject: aNode on: aStream