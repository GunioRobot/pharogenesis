fileOpenName: nameIndex size: nameSize write: writeFlag secure: secureFlag
	"Open the named file, possibly checking security. Answer the file oop."
	| file fileOop okToOpen |
	self var: #file type: 'SQFile *'.
	self var: 'nameIndex' type: 'char *'.
	self export: true.
	fileOop _ interpreterProxy instantiateClass: interpreterProxy classByteArray indexableSize: self fileRecordSize.
	file _ self fileValueOf: fileOop.
	interpreterProxy failed
		ifFalse: [ secureFlag ifTrue: [
				"If the security plugin can be loaded, use it to check for permission.
				If not, assume it's ok"
				sCOFfn ~= 0 
					ifTrue: [okToOpen _ self cCode: '((int (*) (char *, int, int)) sCOFfn)(nameIndex, nameSize, writeFlag)' inSmalltalk:[true].
						okToOpen
							ifFalse: [interpreterProxy primitiveFail]]]].
	interpreterProxy failed
		ifFalse: [self cCode: 'sqFileOpen(file, (int)nameIndex, nameSize, writeFlag)' inSmalltalk: [file]].
	^ fileOop