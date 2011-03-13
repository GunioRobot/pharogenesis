open
Smalltalk isMorphic 
	ifTrue:[^self openAsMorphLabel: prompt inWorld: self currentWorld]
	ifFalse: [^self openLabel: directory pathName]