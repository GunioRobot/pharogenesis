baseUrl: aString
	baseUrl _ aString.
	baseUrl isEmpty ifFalse:[
		baseUrl last = $/ ifFalse:[baseUrl _ baseUrl copyWith: $/].
	].