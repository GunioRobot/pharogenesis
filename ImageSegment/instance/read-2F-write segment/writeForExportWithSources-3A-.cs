writeForExportWithSources: fName
	"Write the segment on the disk with all info needed to reconstruct it in a new image.  For export.  Out pointers are encoded as normal objects on the disk.  Append the source code of any classes in roots.  Target system will quickly transfer the sources to its changes file."

	| fileStream temp classes |
	state = #activeCopy ifFalse: [self error: 'wrong state'].
	(fName includes: $.) ifFalse: [
		^ self inform: 'Please use ''.pr'' or ''.extSeg'' at the end of the file name'.].
	temp _ endMarker.
	endMarker _ nil.
	fileStream _ FileStream newFileNamed: fName.
	fileStream fileOutClass: nil andObject: self.
		"remember extra structures.  Note class names."
	endMarker _ temp.

	"append sources"
	classes _ arrayOfRoots select: [:cls | 
		(cls isKindOf: Behavior) and: [cls theNonMetaClass isSystemDefined]].
	classes size = 0 ifTrue: [^ self].
	fileStream reopen; setToEnd.
	fileStream nextPutAll: '\\!ImageSegment new!\\' withCRs.
	classes do: [:cls | 
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