doLOD: node
	| levels |
	levels _ (node attributeValueNamed: 'level').
	levels size > 0 ifTrue:[
		levels last doWith: self.
	].