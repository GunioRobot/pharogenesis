testToSEFile: filename
	"write SE file with origin
		PNMReadWriter testToSEFile: 'Tools:Squeak3.4:outSE.pbm'.
	"
	| prw f |
	prw _ self new.
	prw stream: ((FileStream newFileNamed: filename) binary).
	prw pragma: '#origin 10 10', String lf.
	f _ Form fromUser.
	prw nextPutImage: f