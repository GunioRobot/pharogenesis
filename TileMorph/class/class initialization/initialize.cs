initialize
	"TileMorph readInArrowGraphics    -- call manually if necessary to bring graphics forward"
	"TileMorph initialize"

	UpdatingOperators _ Dictionary new.
	UpdatingOperators at: #incr: put: #+.
	UpdatingOperators at: #decr: put: #-.
	UpdatingOperators at: #set: put: ''.

	RetractPicture ifNil: [
		RetractPicture _ (SuffixPicture flipBy: #horizontal centerAt: (SuffixPicture center))].
	SuffixArrowAllowance _ 5 + SuffixPicture width + RetractPicture width.
	UpArrowAllowance _ 10.
