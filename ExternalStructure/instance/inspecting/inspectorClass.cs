inspectorClass 
	"Answer the class of the inspector to be used on the receiver.  Called by inspect; 
	use basicInspect to get a normal (less useful) type of inspector."

	self class fields size > 0 
		ifTrue: [^ExternalStructureInspector]
		ifFalse: [^super inspectorClass]