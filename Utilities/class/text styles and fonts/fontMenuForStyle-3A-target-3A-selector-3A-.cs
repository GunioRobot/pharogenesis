fontMenuForStyle: styleName target: target selector: selector
 	| aMenu |
	aMenu _ MenuMorph entitled: styleName.
 	(Utilities pointSizesFor: styleName) do:
		[:aWidth |
			aMenu 
				add: (aWidth asString, ' Point') 
				target: target 
				selector: selector
				argument: ((TextStyle named: styleName) fontOfPointSize: aWidth).
                aMenu lastItem font: ((TextStyle named: styleName) fontOfPointSize: aWidth)].
        ^ aMenu