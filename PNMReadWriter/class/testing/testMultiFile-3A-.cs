testMultiFile: filename
	"write two files from user, then read
		PNMReadWriter testMultiFile: 'Tools:Squeak3.6:outMulti.pbm'.
	"
	| prw f |
	prw := self new.
	prw stream: ((FileStream newFileNamed: filename) binary).
	prw pragma: '#Squeak test', String lf.
	f := Form fromUser. prw nextPutImage: f. 
	f := Form fromUser.prw nextPutImage: f.	
	prw close.
	prw stream: (StandardFileStream readOnlyFileNamed: filename).
	f := prw nextImage. (SketchMorph withForm: f) openInWorld.
	f := prw nextImage. (SketchMorph withForm: f) openInWorld.
