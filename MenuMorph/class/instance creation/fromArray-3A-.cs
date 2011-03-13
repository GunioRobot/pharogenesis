fromArray: anArray 
	"Construct a menu from anArray. The elements of anArray  
	must be either:  
	* A pair of the form: <label> <selector>  
	or	* The 'dash' (or 'minus sign') symbol"
	| menu |

	menu := self new.

	anArray
		do: [:anElement |
			anElement size == 1
				ifTrue: [
					anElement == #- ifFalse: [^ self error: 'badly-formed menu constructor'].
					menu addLine.
				]
				ifFalse: [
					anElement size == 2 ifFalse: [^ self error: 'badly-formed menu constructor'].
					menu add: anElement first action: anElement second.
				]
		].

	^ menu