initialize
	"
	KlattSynthesizerPlugin initialize
	"
	KlattFrame parameterNames
		doWithIndex: [ :each :i | self classPool at: each capitalized asSymbol put: i-1].
	PI _ Float pi	.
	Epsilon _ 1.0e-04