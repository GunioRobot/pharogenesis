alanKwdRepeatForDoing: aNode isAConditional: template key: key args: args

	| nodeWithNilReceiver row column keywords |

	nodeWithNilReceiver _ aNode copy receiver: nil.
	column _ self addColumn: #keyword1 on: nodeWithNilReceiver.
	keywords _ key keywords.
	keywords
		with: (args first: keywords size)
		do: [:kwd :arg |
			(row _ column addRow: #keyword2 on: nodeWithNilReceiver)
				parseNode: (nodeWithNilReceiver as: MessagePartNode).
			row addToken: kwd
				type: #keyword2
				on: KeyWordNode new.
			(arg asMorphicSyntaxIn: row) setConditionalPartStyle.
		].
