addFromTTFile: fileName
"
	Execute the following only if you know what you are doing.
	self addFromTTFile: 'C:\WINDOWS\Fonts\msgothic.TTC'
"

	| tt old |
	(fileName asLowercase endsWith: 'ttf') ifTrue: [
		tt _ TTCFontReader readTTFFrom: (FileStream readOnlyFileNamed: fileName).
	] ifFalse: [
		tt _ TTCFontReader readFrom: (FileStream readOnlyFileNamed: fileName).
	].
		
	old _ TTCDescriptions detect: [:f | f first name = tt first name] ifNone: [nil].
	old ifNotNil: [TTCDescriptions remove: old].
	TTCDescriptions add: tt.
	^ tt.
