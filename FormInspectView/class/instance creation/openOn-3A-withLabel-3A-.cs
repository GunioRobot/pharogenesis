openOn: aFormDictionary withLabel: aLabel
	"open a graphical dictionary in a window having the label aLabel. 
     aFormDictionary should be a dictionary containing as value a form."

     ^ DictionaryInspector
                openOn: aFormDictionary
                withEvalPane: true
                withLabel: aLabel
                valueViewClass: self