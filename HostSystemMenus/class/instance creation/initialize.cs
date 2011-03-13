initialize
	"Add me to the system startup list"
	"self initialize"
	self clearDefault.
	Smalltalk 
		addToStartUpList: self
		after: SmalltalkImage