removeResource: aResource
	"Disconnect and remove the resource."
	
	aResource object: nil.
	^resources remove: aResource