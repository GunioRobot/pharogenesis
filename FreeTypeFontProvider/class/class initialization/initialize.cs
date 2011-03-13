initialize
	"
	self initialize
	"
	Smalltalk removeFromStartUpList: self.
	Smalltalk addToStartUpList: self after: SecurityManager. "actually it needs to be before AutoStart"
		
	"ensure that other classes have also been initialized by forcefully initializing them now.
	It then does not matter which order they are initialized in during the package load"
	FT2Constants initialize.
	FreeTypeCache initialize.
	FreeTypeCacheConstants initialize.
	FreeTypeSettings initialize.

	"an instVar, pendingKernX,  is added to both CharacterScanner and MultiCharacterScanner by 
	the preamble of the package. However, some versions of the monticello loader don't run the
	preamble code. So, we check if the instVars have been added, and if not add them now"
	(CharacterScanner instVarNames includes: 'pendingKernX') ifFalse:[
		Compiler evaluate: 'Object subclass: #CharacterScanner
	instanceVariableNames: ''destX lastIndex xTable destY stopConditions text textStyle alignment leftMargin rightMargin font line runStopIndex spaceCount spaceWidth emphasisCode kern indentationLevel wantsColumnBreaks pendingKernX''
	classVariableNames: ''DefaultStopConditions NilCondition PaddedSpaceCondition SpaceCondition''
	poolDictionaries: ''TextConstants''
	category: ''Graphics-Text'' '].
	(MultiCharacterScanner instVarNames includes: 'pendingKernX') ifFalse:[
Compiler evaluate: 'Object subclass: #MultiCharacterScanner
	instanceVariableNames: ''destX lastIndex xTable destY stopConditions text textStyle alignment leftMargin rightMargin font line runStopIndex spaceCount spaceWidth emphasisCode kern indentationLevel wantsColumnBreaks presentation presentationLine numOfComposition baselineY firstDestX pendingKernX''
	classVariableNames: ''DefaultStopConditions NilCondition PaddedSpaceCondition SpaceCondition''
	poolDictionaries: ''TextConstants''
	category: ''Multilingual-Scanning'' '].			
	
	self current. "this creates an instance of me, and updates from the system"