createBuildFiles 
 "SystemBuilder createBuildFiles" 
	"2/7/96 sw: no builds having yet been undertaken for our new kernel yet, this serves as a placeholder.  carried forward in this method is some old code from macpal building, for future reference...
	2/91:  You must invoke this method from within a project that bears as its change-set all the changes in the system other than code residing in classes in the MacPal categories--otherewise the build files created will not be right.  It does no harm to have changes relating to MacPal categories in the current changeset also, since these are stripped from it as part of the process.  8/91:  Probably will now work fine with whatever changeset you have current; it will leave that current changeset holding all the non-pal changes.  This is the hypothesis, anyway...
	self assimilateGenericChanges.
	self fileOutMacPalWithSuffix: ('.', 'xxx')

createRootBuildNodeWithSuffix: suffix 
	|  stream |
	stream _ (FileStream fileNamed: 'MacPal-FileIn', suffix).

	stream nextPutAll:
'
	(FileStream oldFileNamed: ''MacPal-Changes', suffix, ''') fileIn.'.

	self macPalCategories do:
		[:catName | 
			stream cr; tab; nextPutAll: '(FileStream oldFileNamed: '''.
			stream nextPutAll: catName.
			stream nextPutAll:  suffix, ''') fileIn.'].

	stream nextPutAll: '

	(Smalltalk at: #MacPalBuilder) perform: #finalSystemBuildingSteps
'; shorten; close

fileOutMacPalWithSuffix:  suffix 
	MacPalBuilder fileOutMacPalWithSuffix: 'MP'
	You must invoke this method from within a project that bears as its change-set all the changes in the system other than code residing in classes in the MacPal categories--otherwise the build files created will not be right
	self macPalCategories do:
		[:cat |
		SystemOrganization fileOutCategory: cat withSuffix: suffix.
		(SystemOrganization superclassOrder: cat)
			do: [:class | class removeFromChanges]].

	(FileStream fileNamed: 'MacPal-Changes', suffix) fileOutChanges.

	self createRootBuildNodeWithSuffix: suffix

initialize
	BuildingSystem _ true

macPalCategories
	MacPal macPalCategories
	NB - all class categories starting with the word MacPal are used
	^ SystemOrganization categories select:
		[:aCat | (aCat asString findString:  'MacPal' startingAt: 1) = 1]

rootProjectInfo

You have managed to enter the Non-MacPal-Changes project, perhaps in error! 

Choose 'enter' in the menu to the left to re-enter the main desktop project.  

DO NOT request a ST noChanges when you can see this window!

This project holds the incoming changes to non-MacPal classes in this version of the MacPal image.

It also serves as the project from within which build files are created for the next build.    For this, you need to file in, while in this project, all the non-MacPal changes that have arisen since the incoming baseline image was built, even if they are already in the current image.

MacPalBuilder createBuildFiles."