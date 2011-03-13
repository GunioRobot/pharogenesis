classListIndex: anInteger 
	classListIndex := anInteger.
	classListIndex > 0
		ifTrue: [Browser fullOnClass: self selectedClass selector: self selectedMessageName]