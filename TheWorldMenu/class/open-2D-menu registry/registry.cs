registry
	"Answer the registry of dynamic open commands"
	
	^OpenMenuRegistry ifNil: [OpenMenuRegistry _ OrderedCollection new].
