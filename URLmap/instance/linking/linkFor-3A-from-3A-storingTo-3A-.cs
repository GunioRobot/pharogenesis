linkFor: string from: peer storingTo: aList
	| uString newpage |
	uString _ string asUppercase.
	(uString indexOfSubCollection: 'HTTP' startingAt: 1) = 1
	ifTrue:
		[((uString endsWith: 'GIF') or: [(uString endsWith: 'JPEG') or:
			[uString endsWith: 'JPG']])
		ifTrue: [^'<image src="',string,'">']
		ifFalse: [^'<a href="',string,'">',string,'</a>']]
	ifFalse: "Serious! Gotta provide-a-link!"
		[newpage _ pages at: string asLowercase ifAbsent: [nil].
		newpage isNil ifTrue: [ "Create a new page"
			newpage _ self newpage: string from: peer.].
		(aList indexOf: newpage) ~= 0 ifFalse: [aList add: newpage]. "Add only if not there"
		^self pageURL: newpage]