fileOutClass: modelClass andObject: eToyHolder
	"Write a file that has both code and an object as bits.  tk 6/26/97 12:25"

	| class refStream |
	self setFileTypeToObject.
		"Type and Creator not to be text, so can attach correctly to an email msg"
	self header; timeStamp.

	modelClass ifNotNil: [
		class _ modelClass.	"The model class of this world"
		class sharedPools size > 0 ifTrue:
			[class shouldFileOutPools
				ifTrue: [class fileOutSharedPoolsOn: self]].
		class fileOutOn: self moveSource: false toFile: 0].
	self trailer.	"Does nothing for normal files.  HTML streams will have trouble with object data"

	"Append the object's raw data"
	self cr; cr; nextPutAll: '!SmartRefStream!'.
	self binary.		"redundant"
	refStream _ SmartRefStream on: self.
	refStream nextPut: eToyHolder.  "with its morphs"
		"Terminator, $!, is not doubled inside object data"
	self ascii.
	self nextPutAll: '!'; cr; cr.
	refStream close.		"also closes me"
