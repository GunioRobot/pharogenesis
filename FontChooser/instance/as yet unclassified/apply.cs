apply
	| font |
	target ifNotNil:[
		setSelector ifNotNil:[
			font := self selectedFont.
			font ifNotNil:[
				target perform: setSelector with: font]]].