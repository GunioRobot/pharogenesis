saveOnURLbasic
	"Ask the user for a url and save myself on a SmartReferenceStream file.  Writes out the version and class structure.  The file is fileIn-able.  UniClasses will be filed out."

	| url pg stamp pol |
	(pg _ self valueOfProperty: #SqueakPage) ifNil: [pg _ SqueakPage new]
		ifNotNil: [pg contentsMorph ~~ self ifTrue: [
				self inform: 'morph''s SqueakPage property is out of date'.
				pg _ SqueakPage new]].
	(url _ pg url) ifNil: [
		url _ ServerDirectory defaultStemUrl, '1.sp'.	"A new legal place"
		url _ FillInTheBlank 
				request: 'url of a place to store this object.
Must begin with file:// or ftp://' 
				initialAnswer: url.
		url size == 0 ifTrue: [^ #cancel]].
	stamp _ Utilities authorInitialsPerSe ifNil: ['*'].
	pg saveMorph: self author: stamp.
	SqueakPageCache atURL: url put: pg.	"setProperty: #SqueakPage"
	(pol _ pg policy) ifNil: [pol _ #neverWrite].
	pg policy: #now; dirty: true.  pg write.	"force the write"
	pg policy: pol.
	^ pg