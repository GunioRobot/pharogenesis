cullFace: aSymbol
	"Set backface culling. aSymbol must be either #cw, #ccw or nil."
	| value |
	value _ aSymbol == #cw ifTrue:[1] ifFalse:[
				aSymbol == #ccw ifTrue:[-1] ifFalse:[0]].
	self primRender: handle setProperty: 1 toInteger: value.