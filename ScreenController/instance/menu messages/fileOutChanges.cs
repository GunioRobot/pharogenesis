fileOutChanges 
	"File out changes to a file whose name is a functon of the current date and time.  1/8/96 sw, 1/18/96 sw, 1/31/96 sw"

	Smalltalk changes fileOut.
	self showInTranscript: 'Changes filed out ', Date dateAndTimeNow printString