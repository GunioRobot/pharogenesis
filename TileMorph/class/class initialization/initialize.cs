initialize
	"TileMorph readInArrowGraphics    -- call manually if necessary to bring graphics forward"
	"TileMorph initialize"

	UpdatingOperators _ Dictionary new.
	UpdatingOperators at: #incr: put: #+.
	UpdatingOperators at: #decr: put: #-.
	UpdatingOperators at: #set: put: ''.

	SuffixArrowAllowance _ 12.
	UpArrowAllowance _ 10.
