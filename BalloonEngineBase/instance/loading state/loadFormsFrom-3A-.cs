loadFormsFrom: arrayOop
	"Check all the forms from arrayOop."
	| formOop bmBits bmBitsSize bmWidth bmHeight bmDepth ppw bmRaster |
	(interpreterProxy isArray: arrayOop) ifFalse:[^false].
	formArray _ arrayOop.
	0 to: (interpreterProxy slotSizeOf: formArray) - 1 do:[:i|
		formOop _ interpreterProxy fetchPointer: i ofObject: formArray.
		(interpreterProxy isIntegerObject: formOop) ifTrue:[^false].
		(interpreterProxy isPointers: formOop) ifFalse:[^false].
		(interpreterProxy slotSizeOf: formOop) < 5 ifTrue:[^false].
		bmBits _ interpreterProxy fetchPointer: 0 ofObject: formOop.
		(interpreterProxy fetchClassOf: bmBits) == interpreterProxy classBitmap
			ifFalse:[^false].
		bmBitsSize _ interpreterProxy slotSizeOf: bmBits.
		bmWidth _ interpreterProxy fetchInteger: 1 ofObject: formOop.
		bmHeight _ interpreterProxy fetchInteger: 2 ofObject: formOop.
		bmDepth _ interpreterProxy fetchInteger: 3 ofObject: formOop.
		interpreterProxy failed ifTrue:[^false].
		(bmWidth >= 0 and:[bmHeight >= 0]) ifFalse:[^false].
		ppw _ 32 // bmDepth.
		bmRaster _ bmWidth + (ppw-1) // ppw.
		bmBitsSize = (bmRaster * bmHeight)
			ifFalse:[^false].
	].
	^true