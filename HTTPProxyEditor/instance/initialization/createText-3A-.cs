createText: selector 
"private - create a text widget on selector"
	| widget |
	widget := PluggableTextMorph
				on: self
				text: selector
				accept: (selector , ':') asSymbol.
	widget acceptOnCR: true.
	^ widget