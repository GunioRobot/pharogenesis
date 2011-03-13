storeOnServerWithProgressInfo

	"Save to disk as an Export Segment.  Then put that file on the server I came from, as a new version.  Version is literal piece of file name.  Mime encoded and http encoded."

	ComplexProgressIndicator new 
		targetMorph: nil;
		historyCategory: 'project storing';
		withProgressDo: [self storeOnServerInnards]
	