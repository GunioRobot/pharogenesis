mapHashAt: obj
	"Return the new hash for this object"
	| bucket |
	bucket _ oopMap at: obj identityHash+1.
	1 to: bucket size by: 3 do: 
		[:i | obj == (bucket at: i) ifTrue: [^ bucket at: i+2]].
	self halt