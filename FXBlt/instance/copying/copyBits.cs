copyBits
	"Primitive. Perform the movement of bits from the source form to the 
	destination form. Fail if any variables are not of the right type (Integer, 
	Float, or Form) or if the combination rule is not implemented. 
	In addition to the original 16 combination rules, this BitBlt supports
	16	fail (to simulate paint)
	17	fail (to simulate mask)
	18	sourceWord + destinationWord
	19	sourceWord - destinationWord
	20	rgbAdd: sourceWord with: destinationWord
	21	rgbSub: sourceWord with: destinationWord
	22	rgbDiff: sourceWord with: destinationWord
	23	tallyIntoMap: destinationWord
	24	alphaBlend: sourceWord with: destinationWord
	25	pixPaint: sourceWord with: destinationWord
	26	pixMask: sourceWord with: destinationWord
	27	rgbMax: sourceWord with: destinationWord
	28	rgbMin: sourceWord with: destinationWord
	29	rgbMin: sourceWord bitInvert32 with: destinationWord
"
	| result |
	result _ self primCopyBits.
	result == nil ifFalse:[^result].
raiseErrors == true ifTrue:[^self primitiveFailed].
	self recover ifTrue:[^self copyBits].

	"Check for unimplmented rules"
	combinationRule = Form oldPaint ifTrue: [^ self paintBits].
	combinationRule = Form oldErase1bitShape ifTrue: [^ self eraseBits].

	self error: 'Bad BitBlt arg (Fraction?); proceed to convert.'.
	"Convert all numeric parameters to integers and try again."
	destX _ destX asInteger.
	destY _ destY asInteger.
	width _ width asInteger.
	height _ height asInteger.
	sourceX _ sourceX asInteger.
	sourceY _ sourceY asInteger.
	clipX _ clipX asInteger.
	clipY _ clipY asInteger.
	clipWidth _ clipWidth asInteger.
	clipHeight _ clipHeight asInteger.
	^ self copyBitsAgain