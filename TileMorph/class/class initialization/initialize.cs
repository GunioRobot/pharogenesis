initialize
	"TileMorph readInArrowGraphics    -- call manually if necessary to bring graphics forward"
	"TileMorph initialize"

	UpdatingOperators := Dictionary new.
	UpdatingOperators at: #incr: put: #+.
	UpdatingOperators at: #decr: put: #-.
	UpdatingOperators at: #set: put: ''.

	RetractPicture ifNil: [
		RetractPicture := (SuffixPicture flipBy: #horizontal centerAt: (SuffixPicture center))].
	SuffixArrowAllowance := 5 + SuffixPicture width + RetractPicture width.
	UpArrowAllowance := 10.
