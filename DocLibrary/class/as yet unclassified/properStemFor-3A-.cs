properStemFor: classAndMethod
	"Put 'class method' into proper form as a file name.  Leave upper and lower case.  The fileName must be short enough and have proper characters for all platforms and servers."

	| sz |
	classAndMethod size > 23 ifTrue: ["too long"
		sz _ classAndMethod size.
		"input contains space and :, not . and ;"
		^ (classAndMethod copyFrom: 1 to: 2), 
			((classAndMethod copyFrom: 3 to: sz//2) crc16 printString),
			((classAndMethod copyFrom: sz//2+1 to: sz) crc16 printString)
		].
	^ (classAndMethod copyReplaceAll: ' ' with: '.')
		copyReplaceAll: ':' with: ';'
