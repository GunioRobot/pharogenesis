convertTextStyleNamed: aString
	| style fontSet |
	(style _ TextStyle named: aString) ifNil: [^ self error: 'unknown text style ' , aString].
	fontSet _ self fontSetClass: aString.
	style fontArray do: [:each | fontSet compileFont: each]