compactMultiSymbolTable
	"Reduce the size of the symbol table so that it holds all existing symbols + 25% (changed from 1000 since sets like to have 25% free and the extra space would grow back in a hurry)"

	| oldSize |

	Smalltalk garbageCollect.
	oldSize _ MultiSymbolTable array size.
	MultiSymbolTable growTo: MultiSymbolTable size * 4 // 3 + 100.
	^oldSize printString,'  ',(oldSize - MultiSymbolTable array size) printString, ' slot(s) reclaimed'
