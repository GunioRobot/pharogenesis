morphicWindow
	"ChangeSorter new openAsMorph"
	|  window |

	myChangeSet ifNil: [self myChangeSet: ChangeSet current]. 
	window _ (SystemWindow labelled: self labelString) model: self.
	self openAsMorphIn: window rect: (0@0 extent: 1@1).
	^ window
