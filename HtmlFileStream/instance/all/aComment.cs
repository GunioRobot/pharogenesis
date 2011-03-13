aComment
	"This stream writes legal HTML.  Invoke it with:

((FileStream fileNamed: 'changes.html') asHtml) fileOutChanges

	Meant to masquerade as a StandardFileStream.  Use all the normal methods (for best looks, use method:, methodHeader:, methodBody:, for code).  Use verbatim: to put stuff directly.  Use command: to put out <br>, etc.  Command: it supplies the brackets <>, in normal streams it ignores the data, could be used to bold in Text by recognising 'b', '/b', etc.  Caller should use header and trailer."
	"Override nextPut and do the < > & character transformation.  nextPutAll: calls nextPut."

	"Reading expects HTML file and produces normal Smalltalk code."