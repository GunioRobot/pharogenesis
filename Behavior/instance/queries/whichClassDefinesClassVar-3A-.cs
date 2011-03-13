whichClassDefinesClassVar: aString 
	^self whichSuperclassSatisfies: 
			[:aClass | 
			(aClass classVarNames collect: [:each | each asString]) 
				includes: aString asString]