verifyClass: newClass was: nm selector: sel newList: newShort oldList: oldShort
	"Compare the incoming inst var name lists with the existing class.  See if the proper conversion method is present.  Works for either comparing inst vars for THIS class, or for allInstVars of the superclasses.  "

	Symbol hasInterned: sel ifTrue: [:symb | reshaped at: nm put: symb].
	newShort = oldShort ifFalse: ["Did change inst vars"
		(reshaped includesKey: nm) ifFalse: ["No conversion method exists"
				self close.
				self writeConversionMethod: sel class: newClass was: nm
						fromInstVars: oldShort to: newShort.
				^ 'conversion method needed']]. "you need to restart the read-in"

	(reshaped includesKey: nm) ifTrue: ["Symbol exists"
		(newClass canUnderstand: sel asSymbol) ifFalse: ["But not in this class!"
			self close.
				self writeConversionMethod: sel class: newClass was: nm
						fromInstVars: oldShort to: newShort.
				^ 'conversion method needed']]. "you need to restart the read-in"
	"any other cases to test?"