forURIReturnMimeTypesOrNil: aURI
	| ext fileName mimes |
		
	mimes := aURI schemeIsFile
		ifTrue: 
			[fileName := FileDirectory fullPathForURI: aURI.
			self forFileNameReturnMimeTypesOrNil: fileName]
		ifFalse: 
			[ext := aURI extension.
			self forExtensionReturnMimeTypesOrNil: ext].
	^mimes	
		
