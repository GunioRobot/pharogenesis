setClassAndSelectorIn: csBlock
	"Decode strings of the form    <selectorName> (<className> [class])  "

	| string strm class sel parens |

	self flag: #mref.	"fix for faster references to methods"

	[string _ self selection asString.
	string first == $* ifTrue: [^contents := nil].		"Ignore lines starting with *"
	parens := string includes: $(.					"Does it have open-paren?"
	strm := ReadStream on: string.
	parens
		ifTrue: [strm skipTo: $(.		"easy case"
			class := strm upTo: $).
			strm next: 2.
			sel := strm upToEnd]
		ifFalse: [strm position: (string findString: ' class>>').
			strm position > 0
				ifFalse: [strm position: (string findLast: [ :ch | ch == $ ])]
				ifTrue:
					[ | subString |  "find the next to last space character"
					subString := strm contents copyFrom: 1 to: (string findLast: [ :ch | ch == $ ]) - 1.
					strm position: (subString findLast: [ :ch | ch == $ ])].
		"ifFalse: [strm position: (string findLast: [ :ch | ch == $ ])."
			class := strm upTo: $>.
			strm next.
			sel := strm upToEnd].
	^ MessageSet parse: (class, ' ', sel) toClassAndSelector: csBlock]
		on: Error do: [:ex | ^ contents _ nil]