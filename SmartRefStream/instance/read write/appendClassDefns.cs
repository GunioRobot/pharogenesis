appendClassDefns
	"Make this a fileOut format file.  For each UniClass mentioned, prepend its source code to the file.  Class name conflicts during reading will be resolved then.  Assume instVarInfo: has already been done."

byteStream ascii.
byteStream position = 0 ifTrue: [
	byteStream setFileTypeToObject.
		"Type and Creator not to be text, so can attach correctly to an email msg"
	byteStream header; timeStamp].

byteStream cr; nextPutAll: '!ObjectScanner new initialize!'; cr; cr.
self uniClasesDo: [:class | class
		class hasSharedPools ifTrue:  "This never happens"
			[class shouldFileOutPools
				ifTrue: [class fileOutSharedPoolsOn: self]].
		class fileOutOn: byteStream moveSource: false toFile: 0].	
		"UniClasses are filed out normally, no special format."

	byteStream trailer.	"Does nothing for normal files.  
		HTML streams will have trouble with object data"

	"Append the object's raw data"
	byteStream cr; cr; nextPutAll: '!self smartRefStream!'.
	byteStream binary.		"get ready for objects"
