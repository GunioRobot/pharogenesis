loadFFI
	self new installer monticello http: 'source.squeakfoundation.org'; 
		project: 'FFI'; 
		install: 'FFI-Kernel';
		install: 'FFI-Tests';
		install: 'FFI-Examples'.		
	(Smalltalk at: #ExternalType) initialize.
	(Smalltalk at: #ExternalStructure) compileAllFields.	
	Smalltalk recreateSpecialObjectsArray.