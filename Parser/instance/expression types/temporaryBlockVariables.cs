temporaryBlockVariables
	"Scan and answer temporary block variables."

	| variables |

	(self match: #verticalBar) ifFalse: [
		"There are't any temporary variables."
		^#()].

	variables _ OrderedCollection new.
	[hereType == #word] whileTrue: [variables addLast: (encoder bindBlockTemp: self advance)].
	(self match: #verticalBar) ifTrue: [^variables].
	^self expected: 'Vertical bar'