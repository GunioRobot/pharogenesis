testColorFrom
	self assert: ((Color colorFrom: #white) asHTMLColor = '#ffffff').
	self assert: ((Color colorFrom: #(1.0 0.5 0.0)) asHTMLColor = '#ff7f00').
	self assert: ((Color colorFrom: (Color white)) asHTMLColor = '#ffffff').
	self assert: ((Color colorFrom: '#FF8800') asHTMLColor = '#ff8800').