createLabel: aString 
	"private - create a label with aString"
	| labelWidget |
	labelWidget := PluggableButtonMorph
				on: self
				getState: nil
				action: nil.
	labelWidget hResizing: #spaceFill;
		 vResizing: #spaceFill;
		 label: aString translated.
	""
	labelWidget onColor: Color transparent offColor: Color transparent.

	""
	^ labelWidget