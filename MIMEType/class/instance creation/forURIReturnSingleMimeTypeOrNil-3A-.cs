forURIReturnSingleMimeTypeOrNil: aURI
	| mimes |
	
	mimes := self forURIReturnMimeTypesOrNil: aURI.
	mimes ifNil: [^nil].
	^mimes first
		
