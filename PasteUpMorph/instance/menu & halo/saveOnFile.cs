saveOnFile
	"Ask the user for a filename and save myself on a SmartReferenceStream file.  Writes out the version and class structure.  The file is fileIn-able.  UniClasses will be filed out."

	| aFileName fileStream ok |

	self flag: #bob0302.
	self isWorldMorph ifTrue: [^self project storeLocallyOnly].

	aFileName _ ('my ', self class name) asFileName.	"do better?"
	aFileName _ FillInTheBlank request: 'File name? (".project" will be added to end)' 
			initialAnswer: aFileName.
	aFileName size == 0 ifTrue: [^ self beep].
	self allMorphsDo: [:m | m prepareToBeSaved].

	ok _ aFileName endsWith: '.project'.	"don't double them"
	ok _ ok | (aFileName endsWith: '.sp').
	ok ifFalse: [aFileName _ aFileName,'.project'].
	fileStream _ FileStream newFileNamed: aFileName.
	fileStream fileOutClass: nil andObject: self.	"Puts UniClass definitions out anyway"