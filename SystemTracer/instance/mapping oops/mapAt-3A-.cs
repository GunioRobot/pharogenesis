mapAt: obj
	"Return the new oop for this object"
	| bucket |
	bucket _ oopMap at: obj identityHash+1.
	1 to: bucket size by: 3 do: 
		[:i | obj == (bucket at: i)
			ifTrue: ["Promote this entry for rapid access"
					i > 1 ifTrue: [1 to: 3 do: [:j | bucket swap: j with: i-1+j]].
					^ bucket at: 2]].
	^ UnassignedOop