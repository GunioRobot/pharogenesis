testNewFrom
	"self debug: #testNewFrom"
	| array |
	array := RunArray newFrom: #($a $b $b $b $b $c $c $a).
	self assert: array size = 8.
	self assert: array = #($a $b $b $b $b $c $c $a).