cleanUpCategories
	| list valid removed newList newVers |
	"Look for all conversion methods that can't be used any longer.  Delete them."
	" SmartRefStream cleanUpCategories "

	"Two part selectors that begin with convert and end with a digit."
	"convertasossfe0: varDict asossfeu0: smartRefStrm"
	list _ Symbol selectorsContaining: 'convert'.
	list _ list select: [:symb | (symb beginsWith: 'convert') & (symb allButLast last isDigit)
				ifTrue: [(symb numArgs = 2)]
				ifFalse: [false]].
	valid _ 0.  removed _ 0.
	list do: [:symb |
		(Smalltalk allClassesImplementing: symb) do: [:newClass |
			newList _ (Array with: newClass classVersion), (newClass allInstVarNames).
			newVers _ self new versionSymbol: newList.
			(symb endsWith: (':',newVers,':')) 
				ifFalse: [
					"method is useless because can't convert to current shape"
					newClass removeSelector: symb.	"get rid of it"
					removed _ removed + 1]
				ifTrue: [valid _ valid + 1]]].
	Transcript cr; show: 'Removed: '; print: removed; 
		show: '		Kept: '; print: valid; show: ' '.