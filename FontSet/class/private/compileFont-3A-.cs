compileFont: strikeFont 
	| tempName literalString header |
	tempName _ 'FontTemp.sf2'.
	strikeFont writeAsStrike2named: tempName.
	literalString _ (FileStream readOnlyFileNamed: tempName) contentsOfEntireFile printString.
	header _ 'sizeNNN
	^ self fontNamed: ''NNN'' fromLiteral:
' copyReplaceAll: 'NNN' with: strikeFont name.
	self class
		compile: header , literalString
		classified: 'fonts'
		notifying: nil.
	FileDirectory default deleteFileNamed: tempName