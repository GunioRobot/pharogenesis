installMCZ: aFileName from: stream 

	self classMczInstaller ifNotNilDo: [ :reader | ^reader installStream: stream].  
	self classMCMczReader ifNotNilDo: [ :reader | ^(reader versionFromStream: stream) load]. 

	self error: 'no monticello readers available'. 
 