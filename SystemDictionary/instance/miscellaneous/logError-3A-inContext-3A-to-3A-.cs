logError: errMsg inContext: aContext to: aFilename
	"Log the error message and a stack trace to the given file."

	| ff |

	"wks - 9-09 - do not delete existing errors.  Note that this could be made
	conditional or left here in this state for those who want it.
	FileDirectory default deleteFileNamed: aFilename ifAbsent: []."
	(ff := FileStream fileNamed: aFilename) ifNil: [^ self "avoid recursive errors"].

	[
		"9-09 - move to end."
		ff setToEnd.
		
		"9-09 - write something easy to find to verify correct operation."
		ff nextPutAll:'THERE_BE_DRAGONS_HERE'; cr.
	
	  	ff nextPutAll: errMsg; cr.
		aContext errorReportOn: ff.
		
		"wks 9-09 - write some type of separator"
		ff nextPutAll:( String new:60 withAll:$- ); cr; cr.
	
	] ensure:[
		ff close.
	].
