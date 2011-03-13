testRunsValues
	"self debug: #testRunsValues"
	| array |
	array := RunArray runs: #(1 4 2 1) values: #($a $b $c $a).
	self assert: array size = 8.
	self assert: array = #($a $b $b $b $b $c $c $a).