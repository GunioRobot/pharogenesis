deleteClasses  "Select and execute to get more space in your system."
			"Smalltalk deleteClasses.  Smalltalk spaceLeft"
	#(InstructionPrinter MessageTally GraphicSymbol GraphicSymbolInstance FormButtonCache FormMenuView FormMenuController FormEditor) do:
		[:name | (Smalltalk at: name) removeFromSystem].
	"Reclaim unused Symbols (3K):"
	Symbol rehash.