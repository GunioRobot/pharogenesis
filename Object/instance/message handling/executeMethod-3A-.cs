executeMethod: compiledMethod
	"Execute compiledMethod against the receiver with no args"

	"<primitive: 189>" "uncomment once prim 189 is in VM"
	^ self withArgs: #() executeMethod: compiledMethod