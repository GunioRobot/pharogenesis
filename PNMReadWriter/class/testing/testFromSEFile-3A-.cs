testFromSEFile: filename
	"read SE file, check origin
		PNMReadWriter testFromSEFile: 'Tools:Squeak3.4:eliseSE.pbm'.
	"
	| prw f |
	prw _ self new.
	prw stream: (FileStream readOnlyFileNamed: filename).
	f _ prw nextImage.
	f morphEdit.
	prw inspect