checkIsServiceIsFromDummyTool: service
	
	^ (service instVarNamed: #provider) = DummyToolWorkingWithFileList
	 	& service label = 'menu label'
		& (service instVarNamed: #selector) = #loadAFileForTheDummyTool: