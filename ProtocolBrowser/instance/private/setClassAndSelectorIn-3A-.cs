setClassAndSelectorIn: csBlock
	"Decode strings of the form    <selectorName> (<className> [class])  "

	| i classAndSelString sel |
	sel _ self selection asString.
	i _ sel indexOf: $(.
	"Rearrange to  <className> [class] <selectorName> , and use MessageSet"
	classAndSelString _ (sel copyFrom: i + 1 to: sel size - 1) , ' ' ,
					(sel copyFrom: 1 to: i - 1) withoutTrailingBlanks.
	MessageSet parse: classAndSelString toClassAndSelector: csBlock