format: textOrStream in: aClass notifying: aRequestor contentsSymbol: aSymbol	 
	"Compile a parse tree from the argument, textOrStream. 
	Answer a string containing the original code, formatted nicely."  
	
	self deprecated: 'Use ''format:  in:  notifying:'' instead.'.
	^ self format: textOrStream in: aClass notifying: aRequestor