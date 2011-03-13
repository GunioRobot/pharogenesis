methodDisplayStringForClass: class selector: sel
	
	^ String streamContents: [ :s |
				s nextPutAll: class name ; 
					nextPutAll: ' ' ; nextPutAll: sel ; 
					nextPutAll: ' {' ; 
					nextPutAll: ((class organization categoryOfElement: sel) ifNil: ['']) ;
					nextPutAll: '} ']
				
		"		
					nextPut: $[ ;
					nextPutAll: (PackageOrganizer default mostSpecificPackageOfClass: class ifNone: [PackageInfo named: '**unpackaged**']) packageName ;
					nextPut: $]]."
