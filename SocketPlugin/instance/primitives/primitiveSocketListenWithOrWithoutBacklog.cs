primitiveSocketListenWithOrWithoutBacklog
	"Backward compatibility"
	self export: true.
	interpreterProxy methodArgumentCount = 2
		ifTrue:[^self primitiveSocketListenOnPort]
		ifFalse:[^self primitiveSocketListenOnPortBacklog]
