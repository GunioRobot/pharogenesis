compileFont: strikeFont 
	| tempName literalString header sizeStr familyName |
	tempName _ 'FontTemp.sf2'.
	strikeFont writeAsStrike2named: tempName.
	literalString _ (Base64MimeConverter mimeEncode: (FileStream readOnlyFileNamed: tempName) binary) contents fullPrintString.
	sizeStr _ strikeFont pointSize asString.
	familyName _ strikeFont name first: (strikeFont name findLast: [:x | x isDigit not]).

	header _ 'size' , sizeStr , '
	^ self fontNamed: ''' , familyName , sizeStr , ''' fromMimeLiteral:
' .
	self class
		compile: header , literalString
		classified: 'fonts'
		notifying: nil.
	FileDirectory default deleteFileNamed: tempName
