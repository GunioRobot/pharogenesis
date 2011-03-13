initializeNames
	"Set values of the named colors. 6/13/96 tk
	Color initializeNames"

	ColorNames _ OrderedCollection new.
	#(white black gray yellow red green blue cyan
		magenta - veryDarkGray darkGray - lightGray 
		veryLightGray - )
		doWithIndex:
		[:colorPut :i | colorPut == #- ifFalse:
			[self named: colorPut put: (IndexedColors at: i)]].

	#(lightBlue lightBrown lightCyan lightGray lightGreen lightMagenta lightOrange lightRed lightYellow)
			with:  "Color fromUser first bitAnd: 255"
		#( 219 206 147 37 207 254 236 248 249)
			do: [:colorPut :i | 
				self named: colorPut put: (IndexedColors at: i+1)].
