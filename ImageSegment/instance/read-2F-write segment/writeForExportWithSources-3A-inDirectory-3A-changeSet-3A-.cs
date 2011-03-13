writeForExportWithSources: fName inDirectory: aDirectory changeSet: aChangeSetOrNil
	"Write the segment on the disk with all info needed to reconstruct it in a new image.  For export.  Out pointers are encoded as normal objects on the disk.  Append the source code of any classes in roots.  Target system will quickly transfer the sources to its changes file."

	"An experimental version to fileout a changeSet first so that a project can contain its own classes"



	| fileStream temp tempFileName zipper allClassesInRoots classesToWriteEntirely methodsWithSource |
	state = #activeCopy ifFalse: [self error: 'wrong state'].
	(fName includes: $.) ifFalse: [
		^ self inform: 'Please use ''.pr'' or ''.extSeg'' at the end of the file name'.].
	temp _ endMarker.
	endMarker _ nil.
	tempFileName _ aDirectory nextNameFor: 'SqProject' extension: 'temp'.
	zipper _ [
		ProgressNotification signal: '3:uncompressedSaveComplete'.
		(aDirectory oldFileNamed: tempFileName) compressFile.	"makes xxx.gz"
		aDirectory 
			rename: (tempFileName, FileDirectory dot, 'gz')
			toBe: fName.
		aDirectory
			deleteFileNamed: tempFileName
			ifAbsent: []
	].
	fileStream _ aDirectory newFileNamed: tempFileName.
	fileStream fileOutChangeSet: aChangeSetOrNil andObject: self.
		"remember extra structures.  Note class names."
	endMarker _ temp.

	"append sources"
	allClassesInRoots _ arrayOfRoots select: [:cls | cls isKindOf: Behavior].
	classesToWriteEntirely _ allClassesInRoots select: [ :cls | cls theNonMetaClass isSystemDefined].
	methodsWithSource _ OrderedCollection new.
	allClassesInRoots do: [ :cls |
		(classesToWriteEntirely includes: cls) ifFalse: [
			cls selectorsAndMethodsDo: [ :sel :meth |
				meth sourcePointer = 0 ifFalse: [methodsWithSource add: {cls. sel. meth}].
			].
		].
	].
	(classesToWriteEntirely isEmpty and: [methodsWithSource isEmpty]) ifTrue: [zipper value. ^ self].

	fileStream reopen; setToEnd.
	fileStream nextPutAll: '\\!ImageSegment new!\\' withCRs.
	methodsWithSource do: [ :each |
		fileStream nextPut: $!.	"try to pacify ImageSegment>>scanFrom:"
		fileStream nextChunkPut: 'RenamedClassSourceReader formerClassName: ',
				each first name printString,' methodsFor: ',
				(each first organization categoryOfElement: each second) asString printString,
				' stamp: ',(Utilities timeStampForMethod: each third) printString; cr.
		fileStream nextChunkPut: (each third getSourceFor: each second in: each first) asString.
		fileStream nextChunkPut: ' '; cr.
	].
	classesToWriteEntirely do: [:cls | 
		cls isMeta ifFalse: [fileStream nextPutAll: 
						(cls name, ' category: ''', cls category, '''.!'); cr; cr].
		cls organization
			putCommentOnFile: fileStream
			numbered: 0
			moveSource: false
			forClass: cls.	"does nothing if metaclass"
		cls organization categories do: 
			[:heading |
			cls fileOutCategory: heading
				on: fileStream
				moveSource: false
				toFile: 0]].
	"no class initialization -- it came in as a real object"
	fileStream close.
	zipper value.