floorLog: radix 
	"Quick computation of (self log: radix) floor."
	| x rsq |
	self < radix ifTrue: [^0]. 	"self assumed positive"
	self < (rsq _ radix * radix) ifTrue: [^1].
	x _ 2 * (self floorLog: rsq).	"binary recursion like ipow"
	^x + (self / (radix raisedTo: x) floorLog: radix)