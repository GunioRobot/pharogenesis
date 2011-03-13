nextPut: anObject
	"Really write three objects: (version, class structure, object).  But only when called from the outside.  If any instance-specific classes are present, prepend their source code.  byteStream will be in fileOut format.
	You can see an analysis of which objects are written out by doing: 
	(SmartRefStream statsOfSubObjects: anObject)
	(SmartRefStream tallyOfSubObjects: anObject)
	(SmartRefStream subObjects: anObject ofClass: aClass)"

| info |
topCall == nil 
	ifTrue:
		[topCall _ anObject.  writing _ true. 
		'Please wait while objects are counted' 
			displayProgressAt: Sensor cursorPoint
			from: 0 to: 10
			during: [:bar | info _ self instVarInfo: anObject].
		self appendClassDefns.	"For instance-specific classes"
		'Writing an object file' displayProgressAt: Sensor cursorPoint
			from: 0 to: objCount*4	"estimate"
			during: [:bar |
				objCount _ 0.
				progressBar _ bar.
				self setStream: byteStream.	"set basePos, but keep any class renames"
				super nextPut: ReferenceStream versionCode.
				super nextPut: info.
				super nextPut: anObject].	"<- the real writing"
					"Note: the terminator, $!, is not doubled inside object data"
		"references is an IDict of every object that got written"
		byteStream ascii.
		byteStream nextPutAll: '!'; cr; cr.
		topCall _ writing _ progressBar _ nil]	"reset it"
	ifFalse:
		[super nextPut: anObject.
		progressBar ifNotNil: [progressBar value: (objCount _ objCount + 1)]].
