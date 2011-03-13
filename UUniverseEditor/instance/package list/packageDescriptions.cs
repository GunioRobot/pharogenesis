packageDescriptions
	^self sortedPackages collect: [ :p |		
		p printString. ]