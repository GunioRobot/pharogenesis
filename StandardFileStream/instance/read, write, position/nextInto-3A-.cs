nextInto: aString
	"Fill aString, whose size dictates the size of the read, with characters from the receiver.  1/31/96 sw"
	| count wanted |
	count _ self primRead: fileID into: aString
				startingAt: 1 count: (wanted _ aString size).
	count < wanted ifTrue: [^ aString copyFrom: 1 to: count].
	^ aString