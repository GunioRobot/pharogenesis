scanFolder: directoryUrl from: updateID
	"Scan all update files in the directory starting at updateID+1.  updates.list must be present to tell us the file names."

	| updateList line num |
	updateList _ (ServerFile new fullPath: directoryUrl,'updates.list') asStream.
	[line _ updateList upTo: Character cr.
	updateList atEnd] whileFalse: [
		line first isDigit ifTrue: [
			num _ line splitInteger first.
			num > updateID ifTrue: [
				self scan: (ServerFile new fullPath: directoryUrl,line) asStream
					updateID: num]
			]].
	lastUpdate <= num ifTrue: [
		lastUpdate _ num.
		lastUpdateName _ line splitInteger last].

