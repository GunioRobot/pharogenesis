saveOnURL: suggestedUrlString
	"Save myself on a SmartReferenceStream file.  If I don't already have a url, use the suggested one.  Writes out the version and class structure.  The file is fileIn-able.  UniClasses will be filed out."

	| url pg stamp pol |
	(pg _ self valueOfProperty: #SqueakPage) ifNil: [pg _ SqueakPage new]
		ifNotNil: [pg contentsMorph ~~ self ifTrue: [
				self inform: 'morph''s SqueakPage property is out of date'.
				pg _ SqueakPage new]].
	(url _ pg url) ifNil: [url _ pg urlNoOverwrite: suggestedUrlString].
	stamp _ Utilities authorInitialsPerSe ifNil: ['*'].
	pg saveMorph: self author: stamp.
	SqueakPageCache atURL: url put: pg.	"setProperty: #SqueakPage"
	(pol _ pg policy) ifNil: [pol _ #neverWrite].
	pg policy: #now; dirty: true.  pg write.	"force the write"
	pg policy: pol.
	^ pg