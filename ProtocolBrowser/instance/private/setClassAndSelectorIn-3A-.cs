setClassAndSelectorIn: csBlock
	"Decode strings of the form <selectorName>   (<className> [class])  "
	^ self parse: self selection toClassAndSelector: csBlock