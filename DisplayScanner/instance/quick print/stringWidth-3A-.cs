stringWidth: aString
	"Answer the width of the given string."
	destX _ destY _ 0.
	aString ifNil: [^ 0].
	lastIndex _ 1.		"else the prim will fail"
	self primScanCharactersFrom: 1 to: aString size in: aString
		rightX: 99999	"virtual infinity"
		stopConditions: stopConditions
		kern: kern.
	^ destX
"
	(1 to: 10) collect: [:i | QuickPrint new stringWidth: (String new: i withAll: $A)]
"