alanKwdIfDo: aNode isAConditional: template key: key args: args
	"(know it has more than one arg)"
	| nodeWithNilReceiver column keywords row |

	nodeWithNilReceiver _ aNode copy receiver: nil.
	column _ self addColumn: #keyword1 on: nodeWithNilReceiver.
	"column borderColor: column compoundBorderColor."
	keywords _ key keywords.
	keywords
		with: (args first: keywords size)
		do: [:kwd :arg |
			(row _ column addRow: #keyword2 on: nodeWithNilReceiver)
				parseNode: (nodeWithNilReceiver as: MessagePartNode).
			kwd = 'do:' ifTrue: [
				row addMorphBack: (row transparentSpacerOfSize: 26@6).
			] ifFalse: [
				row addMorphBack: (row transparentSpacerOfSize: 10@6).
			].
			row addTokenSpecialCase: kwd
				type: #keyword2
				on: KeyWordNode new.
			(arg asMorphicSyntaxIn: row) setConditionalPartStyle.
		].
			
