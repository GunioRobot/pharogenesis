loadCompressedShape: points segments: nSegments leftFills: leftFills rightFills: rightFills lineWidths: lineWidths lineFills: lineFills fillIndexList: fillIndexList pointShort: pointsShort
	"Load a compressed shape into the engine.
		WARNING: THIS METHOD NEEDS THE FULL FRAME SIZE!!!!
	"
	| leftRun rightRun widthRun lineFillRun
	leftLength rightLength widthLength lineFillLength
	leftValue rightValue widthValue lineFillValue |

	self inline: false. "Don't you!!!!"

	self var: #points declareC:'int *points'.
	self var: #leftFills declareC:'int *leftFills'.
	self var: #rightFills declareC:'int *rightFills'.
	self var: #lineWidths declareC:'int *lineWidths'.
	self var: #lineFills declareC:'int *lineFills'.
	self var: #fillIndexList declareC:'int *fillIndexList'.

	nSegments = 0 ifTrue:[^0].

	"Initialize run length encodings"
	leftRun _  rightRun _ widthRun _ lineFillRun _ -1.
	leftLength _ rightLength _ widthLength _ lineFillLength _ 1.
	leftValue _ rightValue _ widthValue _ lineFillValue _ 0.

	1 to: nSegments do:[:i|
		"Decrement current run length and load new stuff"
		(leftLength _ leftLength - 1) <= 0 ifTrue:[
			leftRun _ leftRun + 1.
			leftLength _ self shortRunLengthAt: leftRun from: leftFills.
			leftValue _ self shortRunValueAt: leftRun from: leftFills.
			leftValue = 0 ifFalse:[
				leftValue _ fillIndexList at: leftValue-1.
				leftValue _ self transformColor: leftValue.
				engineStopped ifTrue:[^nil]]].
		(rightLength _ rightLength - 1) <= 0 ifTrue:[
			rightRun _ rightRun + 1.
			rightLength _ self shortRunLengthAt: rightRun from: rightFills.
			rightValue _ self shortRunValueAt: rightRun from: rightFills.
			rightValue = 0 ifFalse:[
				rightValue _ fillIndexList at: rightValue-1.
				rightValue _ self transformColor: rightValue]].
		(widthLength _ widthLength - 1) <= 0 ifTrue:[
			widthRun _ widthRun + 1.
			widthLength _ self shortRunLengthAt: widthRun from: lineWidths.
			widthValue _ self shortRunValueAt: widthRun from: lineWidths.
			widthValue = 0 ifFalse:[widthValue _ self transformWidth: widthValue]].
		(lineFillLength _ lineFillLength - 1) <= 0 ifTrue:[
			lineFillRun _ lineFillRun + 1.
			lineFillLength _ self shortRunLengthAt: lineFillRun from: lineFills.
			lineFillValue _ self shortRunValueAt: lineFillRun from: lineFills.
			lineFillValue = 0 ifFalse:[lineFillValue _ fillIndexList at: lineFillValue-1]].
		self loadCompressedSegment: i - 1
			from: points 
			short: pointsShort 
			leftFill: leftValue 
			rightFill: rightValue 
			lineWidth: widthValue 
			lineColor: lineFillValue.
		engineStopped ifTrue:[^nil].
	].