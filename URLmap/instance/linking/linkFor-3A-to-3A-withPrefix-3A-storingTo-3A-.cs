linkFor: string to: peer withPrefix: prefix storingTo: aList
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
		aList add: newpage.
		^'<a href="',prefix,'.',newpage coreID,'">',string,'</a>']