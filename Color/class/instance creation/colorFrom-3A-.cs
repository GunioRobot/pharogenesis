colorFrom: parm
	"Return an instantiated color from parm.  If parm is already a color, return it, else return the result of my performing it if it's a symbol, else just return the thing"
	(parm isKindOf: Color) ifTrue: [^ parm].
	(parm isKindOf: Symbol) ifTrue: [^ self perform: parm].
	^ parm