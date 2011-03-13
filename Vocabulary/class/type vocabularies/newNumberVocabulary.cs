newNumberVocabulary
	"Answer a Vocabulary object representing the Number vocabulary to the list of AllVocabularies" 

	| aVocabulary aMethodCategory aMethodInterface |
	"Vocabulary newNumberVocabulary"

	aVocabulary _ self new vocabularyName: #Number.
		aVocabulary documentation: 'Numbers are things that can do arithmetic, have their magnitudes compared, etc.'.


#((arithmetic 				'Basic numeric operation'
		(* + - / // \\ abs negated quo: reciprocal rem:))
(#'mathematical functions'	'Trigonometric and exponential functions'
		(arcCos arcSin arcTan arcTan: cos exp floorLog: interpolateTo:at: ln log log: raisedTo: raisedToInteger: sin sqrt squared tan))
('comparing'				'Determining which of two numbers is larger'
		(= < > <= >= ~= ~~))
('converting' 				'Converting a number to another form'
		(@ adaptToCollection:andSend: adaptToFloat:andSend: adaptToFraction:andSend: adaptToInteger:andSend: adaptToPoint:andSend: adaptToString:andSend: asInteger asNumber asPoint asSmallAngleDegrees asSmallPositiveDegrees degreesToRadians radiansToDegrees))) do:

		[:item | 
			aMethodCategory _ ElementCategory new categoryName: item first.
			aMethodCategory documentation: item second.
			item third do:
				[:aSelector | 
					aMethodInterface _ MethodInterface new initializeFor: aSelector.
					aVocabulary atKey: aSelector putMethodInterface: aMethodInterface.
					aMethodCategory elementAt: aSelector put: aMethodInterface].
			aVocabulary addCategory: aMethodCategory].

	^ aVocabulary

"
(('truncation and round off' ceiling detentBy:atMultiplesOf:snap: floor roundTo: roundUpTo: rounded truncateTo: truncated)
('testing' basicType even isDivisibleBy: isInf isInfinite isNaN isNumber isZero negative odd positive sign strictlyPositive)
('converting' @ adaptToCollection:andSend: adaptToFloat:andSend: adaptToFraction:andSend: adaptToInteger:andSend: adaptToPoint:andSend: adaptToString:andSend: asInteger asNumber asPoint asSmallAngleDegrees asSmallPositiveDegrees degreesToRadians radiansToDegrees)
('intervals' to: to:by: to:by:do: to:do:)
('printing' defaultLabelForInspector isOrAreStringWith: newTileMorphRepresentative printOn: printStringBase: storeOn: storeOn:base: storeStringBase: stringForReadout)
('comparing' closeTo:)
('filter streaming' byteEncode:)
('as yet unclassified' reduce)"



