readDocumentFile
	"No longer used. Everything is now done in ProjectLauncher."
	"I do not understand the above comment because this method is still called 
		by other methods in the class SystemDictionary so I moved it here- sd - 16 Nov 03"
	
	StartupStamp _ '----STARTUP----', Time dateAndTimeNow printString, ' as ', self imageName.
