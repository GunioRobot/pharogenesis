openScamperOn: aWord
	| aUrl scamperWindow |
	"Open a Scamper web browser on the WordNet entry for this word.  If Scamper is already pointing at WordNet, use the same browser."

	aUrl _ 'http://www.cogsci.princeton.edu/cgi-bin/webwn/', 
		'?stage=1&word=', aWord.
	scamperWindow _ (WebBrowser default ifNil: [^self]) newOrExistingOn: aUrl.
	scamperWindow model jumpToUrl: aUrl asUrl.
	scamperWindow activate.
