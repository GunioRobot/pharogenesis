reportFor: theLine page: thePage on: report 
 	
	[ thePage atEnd ] whileFalse: [ 
		| line |
		line := thePage nextLine.
		self actionMatch: line reportOn: report ifNoMatch: [ report nextPutAll: line; cr. ] 	
	].