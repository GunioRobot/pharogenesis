forURIReturnSingleMimeTypeOrDefault: aURI
	| mimes |
	
	mimes := self forURIReturnMimeTypesOrNil: aURI.
	mimes ifNil: [^MIMEType defaultStream].
	^mimes first
		
