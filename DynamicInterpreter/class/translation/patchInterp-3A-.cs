patchInterp: fileName
	"Interpreter patchInterp: 'Squeak VM PPC'"
	"This will patch out the unneccesary range check (a compare
	 and branch) in the inner interpreter dispatch loop."
	"NOTE: You must edit in the Interpeter file name, and the
	 number of instructions (delta) to count back to find the compare
	 and branch that we want to get rid of."

	| delta f code len remnant i |
	delta _ 6.
	f _ FileStream fileNamed: fileName.
	f binary.
	code _ Bitmap new: (len _ f size) // 4.
	f nextInto: code.
	remnant _ f next: len - (code size * 4).
	i _ 0.
	["Look for a BCTR instruction"
	(i _ code indexOf: 16r4E800420 startingAt: i + 1 ifAbsent: [0]) > 0] whileTrue: [
		"Look for a CMPLWI FF, 6 instrs back"
	       ((code at: i - delta) bitAnd: 16rFFE0FFFF) = 16r280000FF ifTrue: [
	       	"Copy dispatch instrs back over the compare"
			SelectionMenu notify: 'Patching at ', i hex.
			0 to: delta - 2 do: [ :j |
				code at: (i - delta) + j put: (code at: (i - delta) + j + 2).
			].
		].
	].
	f position: 0; nextPutAll: code; nextPutAll: remnant.
	f close.
