openFromFile: preStream fromDirectory: aDirectoryOrNil withProjectView: existingView
	"Reconstitute a Morph from the selected file, presumed to be represent a Morph saved via the SmartRefStream mechanism, and open it in an appropriate Morphic world."
 	| morphOrList proj |

	ProgressNotification signal: '2:fileSizeDetermined ',preStream size printString.
	morphOrList _ preStream asUnZippedStream.
	preStream sleep.		"if ftp, let the connection close"
	ProgressNotification  signal: '3:unzipped'.
	morphOrList _ morphOrList fileInObjectAndCode.
	ProgressNotification  signal: '4:filedIn'.
	ProgressNotification  signal: '9999 about to enter project'.		"the hard part is over"
	(morphOrList isKindOf: ImageSegment) ifTrue: [
		proj _ morphOrList arrayOfRoots 
			detect: [:mm | mm class == Project] 
			ifNone: [^self inform: 'No project found in this file'].
		proj versionFrom: preStream.
		proj lastDirectory: aDirectoryOrNil.
		CurrentProjectRefactoring currentBeParentTo: proj.
		existingView ifNil: [
			Smalltalk isMorphic ifTrue: [
				proj createViewIfAppropriate.
			] ifFalse: [
				ProjectView openAndEnter: proj.
				"Note: in MVC we get no further than the above"
			].
		] ifNotNil: [
			(existingView project isKindOf: DiskProxy) ifFalse: [
				existingView project changeSet name: ChangeSet defaultName
			].
			"proj changeSet name: otherProjectName."	"<<< why would we need this?"
			(existingView owner isKindOf: SystemWindow) ifTrue: [
				existingView owner model: proj
			].
			existingView project: proj.
		].
		^ ProjectEntryNotification signal: proj
	].

	(morphOrList isKindOf: SqueakPage) ifTrue: [
		morphOrList _ morphOrList contentsMorph
	].
	(morphOrList isKindOf: PasteUpMorph) ifFalse: [
		^ self inform: 'This is not a PasteUpMorph or exported Project.'
	].
	(Project newMorphicOn: morphOrList) enter

