platformNameText: aText 
	"set the platform name - this will almost certainly mean replacing the  
	vmMaker with one suited to the platform so we do it anyway."
	| prevVMMaker |
	prevVMMaker _ vmMaker.
	"make a new vmmaker and ensure I depend on it correctly"
	vmMaker _ VMMaker forPlatform: aText string.
	vmMaker logger: logger.
	vmMaker addDependent: self.
	prevVMMaker removeDependent: self.
	"configure the new vmmaker to match the old one"
	[vmMaker loadConfiguration: prevVMMaker configurationInfo.
	vmMaker platformDirectory]
		on: VMMakerException
		do: [self inform: 'Possible problem with path settings or platform name? Check path, permissions or spellings'.
			^ false].
	^ true