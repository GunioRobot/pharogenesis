initialize
	"B3DExponentTable initialize"
	DefaultExponents _ Dictionary new.
	0 to: 2 do:[:i|
		DefaultExponents at: i put: (self using:[:value| value raisedTo: i]).
	].