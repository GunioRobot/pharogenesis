convertFilesNamed: fileName toFamilyNamed: familyName inDirectoryNamed: dirName
		"BDFFontReader convertFilesNamed: 'helvR' toFamilyNamed: 'Helvetica' inDirectoryNamed: '' "

	"This utility converts X11 BDF font files to Squeak .sf2 StrikeFont files."

	"For this utility to work as is, the BDF files must be named 'familyNN.bdf',
	and must reside in the directory named by dirName (use '' for the current directory).
	The output StrikeFont files will be named familyNN.sf2, and will be placed in the
	current directory."

	| f allFontNames sizeChars dir |
	"Check for matching file names."
	dir _ dirName isEmpty
		ifTrue: [FileDirectory default]
		ifFalse: [FileDirectory default directoryNamed: dirName].
	allFontNames _ dir fileNamesMatching: fileName , '##.bdf'.
	allFontNames isEmpty ifTrue: [^ self error: 'No files found like ' , fileName , 'NN.bdf'].
	
	Utilities informUserDuring: [:info |
		allFontNames do: [:fname | 
			info value: 'Converting ', familyName, ' BDF file ', fname, ' to SF2 format'.
			sizeChars _ (fname copyFrom: fileName size + 1 to: fname size) copyUpTo: $. .

			f _ StrikeFont new readBDFFromFile: (dir fullNameFor: fname) name: familyName, sizeChars.
			f writeAsStrike2named: familyName, sizeChars, '.sf2'.
		].
	]