initialize
	"Initialize the receiver (automatically called when instances are created via 'new')"

	| aMethodCategory aMethodInterface |
	super initialize.
	"Vocabulary replaceNumberVocabulary"
	"Vocabulary addVocabulary: Vocabulary newNumberVocabulary"

	self vocabularyName: #Number.
	self documentation: 'Numbers are things that can do arithmetic, have their magnitudes compared, etc.'.

#((comparing				'Determining which of two numbers is larger'
		(= < > <= >= ~= ~~))
(arithmetic 				'Basic numeric operation'
		(* + - / // \\ abs negated quo: rem:))
(testing 					'Testing a number'
		(even isDivisibleBy: negative odd positive sign))
(#'mathematical functions'	'Trigonometric and exponential functions'
		(cos exp ln log log: raisedTo: sin sqrt squared tan raisedToInteger:))
(converting 				'Converting a number to another form'
		(@ asInteger asPoint degreesToRadians radiansToDegrees asSmallAngleDegrees asSmallPositiveDegrees))
(#'truncation and round off' 'Making a real number (with a decimal point) into an integer'
		(ceiling floor roundTo: roundUpTo: rounded truncateTo: truncated))
) do:

		[:item | 
			aMethodCategory _ ElementCategory new categoryName: item first.
			aMethodCategory documentation: item second.
			item third do:
				[:aSelector | 
					aMethodInterface _ MethodInterface new conjuredUpFor: aSelector class: (Number whichClassIncludesSelector: aSelector).
					aMethodInterface argumentVariables do:
							[:var | var variableType: #Number].

					(#(* + - / // \\ abs negated quo: rem:
						cos exp ln log log: raisedTo: sin sqrt squared tan raisedToInteger:
						asInteger degreesToRadians radiansToDegrees asSmallAngleDegrees asSmallPositiveDegrees)
							includes: aSelector) ifTrue:
								[aMethodInterface resultType: #Number].

					(#( @  asPoint ) includes: aSelector) ifTrue:
						[aMethodInterface resultType: #Point].

					(#(= < > <= >= ~= ~~ even isDivisibleBy: negative odd positive) includes: aSelector) ifTrue:
						[aMethodInterface resultType: #Boolean].

					aMethodInterface setNotToRefresh.  
					self atKey: aSelector putMethodInterface: aMethodInterface.
					aMethodCategory elementAt: aSelector put: aMethodInterface].
			self addCategory: aMethodCategory].

"
(('truncation and round off' ceiling detentBy:atMultiplesOf:snap: floor roundTo: roundUpTo: rounded truncateTo: truncated)
('testing' basicType even isDivisibleBy: isInf isInfinite isNaN isNumber isZero negative odd positive sign strictlyPositive)
('converting' @ adaptToCollection:andSend: adaptToFloat:andSend: adaptToFraction:andSend: adaptToInteger:andSend: adaptToPoint:andSend: adaptToString:andSend: asInteger asNumber asPoint asSmallAngleDegrees asSmallPositiveDegrees degreesToRadians radiansToDegrees)
('intervals' to: to:by: to:by:do: to:do:)
('printing' defaultLabelForInspector isOrAreStringWith: newTileMorphRepresentative printOn: printStringBase: storeOn: storeOn:base: storeStringBase: stringForReadout)
('comparing' closeTo:)
('filter streaming' byteEncode:)
('as yet unclassified' reduce)"



