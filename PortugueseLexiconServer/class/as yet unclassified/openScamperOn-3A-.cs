openScamperOn: aWord
	| aUrl scamperWindow |
	"Open a Scamper web browser on the web dictionary entry for this word.  If Scamper is already pointing at it, use the same browser.  Special code for this server."

	aUrl _ 'http://www.priberam.pt/scripts/dlpouniv.dll', 
		'?search_value=', (self decodeAccents: aWord).
	scamperWindow _ (WebBrowser default ifNil: [^self]) newOrExistingOn: aUrl.
	scamperWindow model jumpToUrl: aUrl asUrl.
	scamperWindow activate.
