entries 
	"Return a collection of directory entries for the files and directories in this directory. Each entry is a five-element array: (<name> <creationTime> <modificationTime> <dirFlag> <fileSize>)."
	| dir ftpEntries thisYear tokens dateInSeconds longy thisMonth theDay theMonth |
	"We start with ftp directory entries of the form...
d---------   1 owner    group               0 Apr 27 22:01 blasttest
----------   1 owner    group           93812 Jul 21  1997 COMMAND.COM
    1        2   3           4                 5    6  7    8       9   -- token index"
	type == #file ifTrue: [
		urlObject isAbsolute ifFalse: [urlObject default].
		^ (FileDirectory on: urlObject pathForDirectory) entries].

	dir _ self getDirectory.
	(dir respondsTo: #contentsOfEntireFile) ifFalse: [^ #()].
	ftpEntries _ dir contentsOfEntireFile findTokens: FTPSocket crLf.

	thisYear _ Date today year.
	thisMonth _ Date today monthIndex.
	^ ftpEntries collect:
		[:ftpEntry | tokens _ ftpEntry findTokens: ' '.
		tokens size >= 9
		ifTrue:
		[tokens size > 9 ifTrue:
			[longy _ tokens at: 9.
			10 to: tokens size do: [:i | longy _ longy , ' ' , (tokens at: i)].
			tokens at: 9 put: longy].
		theDay _ (tokens at: 7) asNumber.
		theMonth _ Date indexOfMonth: (tokens at: 6).
		dateInSeconds _ ((tokens at: 8) includes: $:)
			ifTrue: ["Date has no year if within six months"
					(Date newDay: theDay
							month: theMonth
							year: (theMonth > thisMonth
										ifTrue: [thisYear - 1]
										ifFalse: [thisYear])) asSeconds +
					(Time readFrom: (ReadStream on: (tokens at: 8))) asSeconds]
			ifFalse: [(Date newDay: theDay
							month: theMonth
							year: (tokens at: 8) asNumber) asSeconds].
		DirectoryEntry name: (tokens at: 9)  "file name"
			creationTime: dateInSeconds "creation date"
			modificationTime: dateInSeconds "modification time"
			isDirectory: tokens first first = $d "is-a-directory flag"
			fileSize: tokens fifth asNumber "file size"]
		ifFalse:
		[nil]]
		thenSelect: [:entry | entry notNil]