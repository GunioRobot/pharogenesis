transformY: aFloatArray
	| focus subArray dMaxY |

	focus _ srcExtent y asFloat / 2.

	(aFloatArray at: 1) <= focus ifTrue: [
		dMaxY _ 0.0 - focus.
	] ifFalse: [
		dMaxY _ focus.    " = (size - focus)".
	].
		
	subArray _ self g: (aFloatArray copyFrom: 1 to: gridNum x + 1) max: dMaxY focus: focus.

	aFloatArray replaceFrom: 1 to: gridNum x + 1 with: subArray startingAt: 1.

