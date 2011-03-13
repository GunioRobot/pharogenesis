atEnd
	"Answer whether the receiver is at its end.  2/12/96 sw"
"
	^ self primAtEnd: fileID
"
	"Cache the file size"
	sizeCache == nil ifTrue: [sizeCache _ self primSize: fileID].
	(self primGetPosition: fileID) >= sizeCache
		ifTrue: ["If the cache says we're at end,
				check it again, in case we have written some"
				sizeCache _ self primSize: fileID.
				^ (self primGetPosition: fileID) >= sizeCache]
		ifFalse: [^ false]