nextPut: anObject
	"Really write three objects: (version, class structure, object). But only when called from the outside.  "

	| info |
	topCall == nil 
		ifTrue:
			[topCall _ anObject.  writing _ true. 
			super nextPut: ReferenceStream versionCode.
			'Please wait while objects are counted' displayProgressAt: Sensor cursorPoint
				from: 0 to: 10
				during: [:bar |
					info _ self instVarInfo: anObject].
			'Writing an object file' displayProgressAt: Sensor cursorPoint
				from: 0 to: objCount*4	"estimate"
				during: [:bar |
					objCount _ 0.
					progressBar _ bar.
					super nextPut: info.
					super nextPut: anObject].	"<- the real writing"
			"references is an IDict of every object that got written
			(in case you want totake statistics)"
			"Transcript cr; show: structures keys printString."		"debug"
			topCall _ writing _ progressBar _ nil]	"reset it"
		ifFalse:
			[super nextPut: anObject.
			progressBar ifNotNil: [progressBar value: (objCount _ objCount + 1)]].