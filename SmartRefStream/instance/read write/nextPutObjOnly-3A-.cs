nextPutObjOnly: anObject
	"Really write three objects: (version, class structure, object).  But only when called from the outside.  Not in fileOut format.  No class definitions will be written for instance-specific classes.  Error if find one.  (Use nextPut: instead)"

	| info |
	topCall == nil 
		ifTrue:
			[topCall _ anObject.
			super nextPut: ReferenceStream versionCode.
			'Please wait while objects are counted' displayProgressAt: Sensor cursorPoint
				from: 0 to: 10
				during: [:bar |
					info _ self instVarInfo: anObject].
			self uniClasesDo: [:cls | cls error: 'Class defn not written out.  Proceed?'].
			'Writing an object file' displayProgressAt: Sensor cursorPoint
				from: 0 to: objCount*4	"estimate"
				during: [:bar |
					objCount _ 0.
					progressBar _ bar.
					super nextPut: info.
					super nextPut: anObject.	"<- the real writing"
					"Class inst vars not written here!"].
			"references is an IDict of every object that got written
			(in case you want to take statistics)"
			"Transcript cr; show: structures keys printString."		"debug"
			topCall _ progressBar _ nil]	"reset it"
		ifFalse:
			[super nextPut: anObject.
			progressBar ifNotNil: [progressBar value: (objCount _ objCount + 1)]].