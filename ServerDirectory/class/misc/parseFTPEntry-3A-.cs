parseFTPEntry: ftpEntry
	| tokens longy dateInSeconds thisYear thisMonth |
	thisYear _ Date today year.
	thisMonth _ Date today monthIndex.
	tokens _ ftpEntry findTokens: ' '.
	tokens size = 8 ifTrue:
		[((tokens at: 6) size ~= 3 and: [(tokens at: 5) size = 3]) ifTrue:
			["Fix for case that group is blank (relies on month being 3 chars)"
			tokens _ tokens copyReplaceFrom: 4 to: 3 with: {'blank'}]].
	tokens size >= 9 ifFalse:[^nil].

	((tokens at: 6) size ~= 3 and: [(tokens at: 5) size = 3]) ifTrue:
		["Fix for case that group is blank (relies on month being 3 chars)"
		tokens _ tokens copyReplaceFrom: 4 to: 3 with: {'blank'}].

	tokens size > 9 ifTrue:
		[longy _ tokens at: 9.
		10 to: tokens size do: [:i | longy _ longy , ' ' , (tokens at: i)].
		tokens at: 9 put: longy].
	dateInSeconds _ self
		secondsForDay: (tokens at: 7) 
		month: (tokens at: 6) 
		yearOrTime: (tokens at: 8) 
		thisMonth: thisMonth 
		thisYear: thisYear.
	^DirectoryEntry name: (tokens at: 9)  "file name"
		creationTime: dateInSeconds "creation date"
		modificationTime: dateInSeconds "modification time"
		isDirectory: tokens first first = $d "is-a-directory flag"
		fileSize: tokens fifth asNumber "file size"
