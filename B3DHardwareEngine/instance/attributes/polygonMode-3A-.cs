polygonMode: aSymbol
	"Set the current polygon mode (either #points, #lines or nil)"
	| value |
	value _ aSymbol == #lines ifTrue:[1] ifFalse:[
				aSymbol == #points ifTrue:[2] ifFalse:[0]].
	self primRender: handle setProperty: 2 toInteger: value.