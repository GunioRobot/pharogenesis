name: name0  negated: isNegated0 attribs: attribs0
	"initialize from the given attributes"
	name _ name0.
	isNegated _ isNegated0.
	attribs _ attribs0 ifNil: [Dictionary new]