text: theString back: bytes
	"Record the name of this page during startup.  When reading the page in
order to serve it, this is NOT executed.  The text is read from the file
explicitly."

"Which means that you'd better not cascade text & back or you're royally
screwed ;) BJP"