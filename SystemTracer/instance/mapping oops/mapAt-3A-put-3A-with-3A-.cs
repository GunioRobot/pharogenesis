mapAt: obj put: oop with: hash
	"Assign the new oop for this object"
	| bucket |
	bucket _ oopMap at: obj identityHash+1.

	"Check for multiple writes (debug only)"
"	1 to: bucket size by: 3 do: 
		[:i | obj == (bucket at: i) ifTrue: [self halt]].
"
	oopMap at: obj identityHash+1 put: (Array with: obj with: oop with: hash) , bucket