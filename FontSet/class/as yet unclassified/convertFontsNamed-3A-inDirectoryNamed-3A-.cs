convertFontsNamed: familyName inDirectoryNamed: dirName
		"FontSet convertFontsNamed: 'Tekton' inDirectoryNamed: 'Tekton Fonts' "
	"This utility is for use after you have used BitFont to produce data files 
	for the fonts you wish to use.  It will read the BitFont files and build
	a fontset class from them.  If one already exists, the sizes that can be
	found will be overwritten."
	"For this utility to work as is, the BitFont data files must be named 'familyNN.BF',
	and must reside in the directory named by dirName (use '' for the current directory)."

	| f allFontNames className fontSet sizeChars header fontString tempName dir |
	"Check first for matching file names and usable FontSet class name."
	dir _ dirName isEmpty
		ifTrue: [FileDirectory default]
		ifFalse: [FileDirectory default directoryNamed: dirName].
	allFontNames _ dir fileNamesMatching: familyName , '##.BF'.
	allFontNames isEmpty ifTrue: [^ self halt: 'No files found like ' , familyName , 'NN.BF'].
	className _ (familyName select: [:c | c isAlphaNumeric]) capitalized asSymbol.
	(Smalltalk includesKey: className)
		ifTrue: ["Check that this is already a FontSet"
				((fontSet _ Smalltalk at: className) inheritsFrom: self)
					ifFalse: [self halt: 'The name ' , familyName , ' is already in use']]
		ifFalse: [fontSet _ self subclass: className
					instanceVariableNames: '' classVariableNames: ''
					poolDictionaries: '' category: self category].
	tempName _ 'FontTemp.sf2'.
	allFontNames do:
		[:fname | Transcript cr; show: fname.
		f _ StrikeFont new readFromBitFont: (dir fullNameFor: fname).
		f writeAsStrike2named: tempName.
		fontString _ (FileStream oldFileNamed: tempName) contentsOfEntireFile.
		sizeChars _ (fname copyFrom: familyName size + 1 to: fname size) copyUpTo: $. .
		header _ 'sizeNN
	^ self size: NN fromLiteral:
' copyReplaceAll: 'NN' with: sizeChars.
		fontSet class compile: header , fontString printString
			classified: 'font creation' notifying: nil].
	FileDirectory default deleteFileNamed: tempName.
