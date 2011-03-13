format: textOrStream in: aClass notifying: aRequestor contentsSymbol: aSymbol
	"Compile a parse tree from the argument, textOrStream. Answer a string containing the original code, formatted nicely.  If aSymbol is #colorPrint, then decorate the resulting text with color and hypertext actions"

	^self format: textOrStream in: aClass notifying: aRequestor decorated: (aSymbol == #colorPrint)