setClassAndSelectorIn: csBlock
	"Decode strings of the form <className> [class] <selectorName>."
	^ MessageSet parse: self selection toClassAndSelector: csBlock