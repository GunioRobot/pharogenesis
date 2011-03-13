addUpdatePathTo: aClass from: highRoot 
	aClass withAllSuperclassesDo: [:sc | classesToUpdate add: sc. highRoot = sc ifTrue: [^self]]