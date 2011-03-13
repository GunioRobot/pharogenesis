openAsMorph
	"ChangeSorter new openAsMorph"
	|  window |

	myChangeSet ifNil: [self myChangeSet: Smalltalk changes]. 
	window _ (SystemWindow labelled: self labelString) model: self.
	self openAsMorphIn: window rect: (0@0 extent: 1@1).
	World ifNil: [^ window openInMVC].  "test"
	window openInWorld