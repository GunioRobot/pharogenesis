floatPrecisionForDecimalPlaces: places
	"Answer the floatPrecision that corresponds to the given number of decimal places"

	^ #(1 0.1 0.01 0.001 0.0001 0.00001 0.000001 0.0000001 0.00000001 0.000000001) at: (places + 1)

"
(0 to: 6) collect: [:i | Utilities floatPrecisionForDecimalPlaces: i]
"