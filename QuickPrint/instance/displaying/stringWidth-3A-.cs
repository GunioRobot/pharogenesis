stringWidth: aString
	"Answer the width of the given string."
	destX _ 0.
	destY _ 0.
	self scanCharactersFrom: 1 to: aString size in: aString
		rightX: 99999	"virtual infinity"
		stopConditions: stopConditions
		displaying: false.
	^ destX
"
	(1 to: 10) collect: [:i | QuickPrint new stringWidth: (String new: i withAll: $A)]
"