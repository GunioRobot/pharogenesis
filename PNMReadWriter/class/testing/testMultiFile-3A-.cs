testMultiFile: filename
	"write two files from user, then read
		PNMReadWriter testMultiFile: 'Tools:Squeak3.6:outMulti.pbm'.
	"
	| prw f |
	prw _ self new.
	prw stream: ((FileStream newFileNamed: filename) binary).
	prw pragma: '#Squeak test', String lf.
	f _ Form fromUser. prw nextPutImage: f. 
	f _ Form fromUser.prw nextPutImage: f.	
	prw close.
	prw stream: (FileStream readOnlyFileNamed: filename).
	f _ prw nextImage. (SketchMorph withForm: f) openInWorld.
	f _ prw nextImage. (SketchMorph withForm: f) openInWorld.
