on: targetObject selector: aSymbol 
	"answer a new instance of the receiver on a given target and selector"
	^ self new getSelector: aSymbol;
		 target: targetObject