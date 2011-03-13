doPrintToPrinter

	"fileName _ ('gee.',Time millisecondClockValue printString,'.eps') asFileName."

	DSCPostscriptCanvasToDisk 
		morphAsPostscript: self 
		rotated: self printSpecs landscapeFlag

