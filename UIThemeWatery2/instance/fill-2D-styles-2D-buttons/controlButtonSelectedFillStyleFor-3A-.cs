controlButtonSelectedFillStyleFor: aButton
	"Return the selected control button fillStyle for the given button.
	Control buttons are generally used for drop-lists and expanders."
	
	|round roundCorners tl t tr l m r bl b br tlw trw blw brw|
	round := aButton wantsRoundedCorners.
	roundCorners := aButton roundedCorners.
	tl := (round and: [roundCorners includes: 1]) ifTrue: [self buttonTopLeftForm] ifFalse: [self buttonSquareTopLeftForm].
	tlw := (round and: [roundCorners includes: 1]) ifTrue: [tl width] ifFalse: [4].
	t := self buttonTopMiddleForm.
	tr := (round and: [roundCorners includes: 4]) ifTrue: [self buttonTopRightForm] ifFalse: [self buttonSquareTopRightForm].
	trw := (round and: [roundCorners includes: 4]) ifTrue: [tr width] ifFalse: [4].
	l := self buttonMiddleLeftForm. m := Color r: 102 g: 127 b: 168 range: 255. r := self buttonMiddleRightForm.
	bl := (round and: [roundCorners includes: 2]) ifTrue: [self buttonBottomLeftForm] ifFalse: [self buttonSquareBottomLeftForm].
	blw := (round and: [roundCorners includes: 2]) ifTrue: [bl width] ifFalse: [4].
	b := self buttonBottomMiddleForm.
	br := (round and: [roundCorners includes: 3]) ifTrue: [self buttonBottomRightForm] ifFalse: [self buttonSquareBottomRightForm].
	brw := (round and: [roundCorners includes: 3]) ifTrue: [br width] ifFalse: [4].
	^self
		multiFormFillStyleFrom: {tl. t. tr. l. m. r. bl. b. br}
		cornerWidths: {tlw. trw. blw. brw}
		in: aButton bounds