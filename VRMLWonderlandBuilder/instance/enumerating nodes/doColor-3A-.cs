doColor: node
	| colors |
	colors _ (node attributeValueNamed: 'color').
	attributes at: #currentColors put: (colors collect:[:c| c asB3DColor])