scanUpdatesIn: directoryUrl
	"Scan all update files in the directory starting at lastUpdate+1.  Create a .ix file on my local hard disk.  updates.list must be present to tell us the file names."

	| updateList line num temp out |
	updateList _ (ServerFile new fullPath: directoryUrl,'updates.list') asStream.
	temp _ WriteStream on: (String new: 2000).
	[line _ updateList upTo: Character cr.
	updateList atEnd] whileFalse: [
		line first isDigit ifTrue: [
			num _ line splitInteger first.
			num > lastUpdate ifTrue: [
				self scan: (ServerFile new fullPath: directoryUrl,line) asStream
					updateID: num writeOn: temp]
			]].
	num >= lastUpdate ifTrue: [
		out _ FileStream newFileNamed: 'to', num asString, '.ix'.
		out nextPutAll: 'External ', num asString; space. 
		line splitInteger last storeOn: out.	"quoted"
		out cr; nextPutAll: lastUpdate asString, '.ix' "; cr".	"temp begins with cr"
		out nextPutAll: temp contents; close.
		self inform: 'Rename latest.ix to ', lastUpdate asString, 
			'.ix on both external servers.
Put to', num asString, '.ix on both and call it latest.ix'].
	