asPostscript

	| temp |
	temp _ self asString copyReplaceAll: '(' with: '\('.
	temp _ temp copyReplaceAll: ')' with: '\)'.
	temp _ temp copyReplaceAll: '
' 
			with: ''.
	^ temp